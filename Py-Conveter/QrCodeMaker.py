import os
import shutil
import requests
import urllib.parse
from AppliedMethodes import Methodes
import qrcode


class Program:
    def __init__():
        pass

    def GenerateQr(DestUrl,OutputPath,UserIp):
        if(DestUrl,OutputPath,UserIp != None):
            url = urllib.parse.quote_plus(DestUrl)
            OutPath=f"{Methodes.FixRequestFormat(OutputPath)}\\{UserIp}"
            FileName =list({Methodes.ReturnQrImageName('.png')})
            Methodes.CreateDirectory(OutPath)
            
            try:
                # Generate the QR code
                qr = qrcode.QRCode(version=1, error_correction=qrcode.constants.ERROR_CORRECT_L, box_size=10, border=4)
                qr.add_data(url)
                qr.make(fit=True)

                # Create an image from the QR code
                qr_image = qr.make_image(fill_color="black", back_color="white")

                # Save the image
                qr_image.save(f"{OutPath}\\{FileName[0]}")
                return {'Success':True,'Message':'QrImageMaked','OutFile':FileName[0],'OutPath':Methodes.ReverseRequestFormat(OutPath)}
            except:
                return {'Success':False,'Message':'Bad Request'}
        else:
            return {'Success':False,'Message':'Error Input Cannot Be null'}

    def LinkShorter(LongUrl):
        pass
