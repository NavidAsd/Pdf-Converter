import os
import time
import fitz
import datetime


class Extract():
    
    def __init__(self,Filename,Outpath,InputPath):
            self.Filename = Filename
            self.Outpath = Outpath
            self.InputPath = InputPath

            if not os.path.exists(Outpath):  # make subfolder if necessary
                os.mkdir(Outpath)

            self.dimlimit = 0 # 100  # each image side must be greater than this
            self.relsize = 0 # 0.05  # image : image size ratio must be larger than this (5%)
            self.abssize = 0 # 2048  # absolute image size limit 2 KB: ignore if smaller
            self.t0 = time.time()
            self.doc = fitz.open(f'{self.InputPath}\\{self.Filename}')
            self.page_count = self.doc.page_count
            self.xreflist = []
            self.imglist = []
            self.imgFnamelist = []
            
            


    #if not tuple(map(int, fitz.version[0].split("."))) >= (1, 18, 18):
        #raise SystemExit("require PyMuPDF v1.18.18+")
    #dimlimit = 0  # 100  # each image side must be greater than this
    #relsize = 0  # 0.05  # image : image size ratio must be larger than this (5%)
    #abssize = 0  # 2048  # absolute image size limit 2 KB: ignore if smaller


    def recoverpix(self,doc, item):
        xref = item[0]  # xref of PDF image
        smask = item[1]  # xref of its /SMask

        # special case: /SMask or /Mask exists
        if smask > 0:
            pix0 = fitz.Pixmap(doc.extract_image(xref)["image"])
            if pix0.alpha:  # catch irregular situation
                pix0 = fitz.Pixmap(pix0, 0)  # remove alpha channel
            mask = fitz.Pixmap(doc.extract_image(smask)["image"])

            try:
                pix = fitz.Pixmap(pix0, mask)
            except:  # fallback to original base image in case of problems
                pix = fitz.Pixmap(doc.extract_image(xref)["image"])

            if pix0.n > 3:
                ext = "pam"
            else:
                ext = "png"

            return {  # create dictionary expected by caller
                "ext": ext,
                "colorspace": pix.colorspace.n,
                "image": pix.tobytes(ext),
            }

        # special case: /ColorSpace definition exists
        # to be sure, we convert these cases to RGB PNG images
        if "/ColorSpace" in doc.xref_object(xref, compressed=True):
            pix = fitz.Pixmap(doc, xref)
            pix = fitz.Pixmap(fitz.csRGB, pix)
            return {  # create dictionary expected by caller
                "ext": "png",
                "colorspace": 3,
                "image": pix.tobytes("png"),
            }
        return doc.extract_image(xref)

    def loop(self):
        for pno in range(self.page_count):
            il = self.doc.get_page_images(pno)
            self.imglist.extend([x[0] for x in il])
            for img in il:
                xref = img[0]
                if xref in self.xreflist:
                    continue
                width = img[2]
                height = img[3]
                if min(width, height) <= self.dimlimit:
                    continue
                image = self.recoverpix(self.doc, img)
                n = image["colorspace"]
                imgdata = image["image"]

                if len(imgdata) <= self.abssize:
                    continue
                if len(imgdata) / (width * height * n) <= self.relsize:
                    continue

                imgfile = os.path.join(self.Outpath, "img%05i.%s" % (xref, image["ext"]))
                fout = open(imgfile, "wb")
                fout.write(imgdata)
                fout.close()
                self.xreflist.append(xref)
                self.imgFnamelist.append("img%05i.%s" % (xref, image["ext"])) # img list for result
        self.done()

    
    def done(self):
        t1 = time.time()
        self.imglist = list(set(self.imglist))
        print(f'[fitz] run at {datetime.datetime.now()}')
        print(len(set(self.imglist)), "images in total")
        print(len(self.xreflist), "images extracted")
        print("proccess time %g sec" % (t1 - self.t0))
