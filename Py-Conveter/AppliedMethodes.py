import zipfile
from datetime import datetime
import os
  
class Methodes():
    def __init__():
        pass

    def CompressFilesToZipWithoutPath(lstFiles,OutFilePath,OutFileName,FilesPath):
        # Select the compression mode ZIP_DEFLATED for compression
        compression = zipfile.ZIP_DEFLATED

        # create the zip file 
        zf = zipfile.ZipFile(f"{OutFilePath}\\{OutFileName}", mode="w")
        try:
            for file_name in lstFiles:
                # Add file to the zip file
                #file_name = f'{FilesPath}\\{file_name}'
                zf.write(f'{FilesPath}\\{file_name}',file_name, compress_type=compression)
            return True
        except:
            return False
        finally:
            zf.close()



    def CompressFilesToZip(lstFiles,OutFilePath,OutFileName,):
        # Select the compression mode ZIP_DEFLATED for compression
        compression = zipfile.ZIP_DEFLATED

        # create the zip file 
        zf = zipfile.ZipFile(f"{OutFilePath}\\{OutFileName}", mode="w")
        try:
            for file_name in lstFiles:
                # Add file to the zip file
                zf.write(file_name,os.path.basename(file_name), compress_type=compression)
            return True
        except:
            return False
        finally:
            zf.close()

    def ReturnFileName(Format,ModifiedTo):
        return Methodes.FixStrName(f'PdftoConverter.com-ModifiedTo{ModifiedTo}_{Methodes.FixDateTimeFormt(str(datetime.now()))}{Format}')

    def ReturnFileNameWithoutDate(Format,Text,Count):
        return Methodes.FixStrName(f'{Text}_{Count}{Format}')

    def ReturnFileNameWithoutModifie(Format,ModifiedTo):
        return Methodes.FixStrName(f'PdftoConverter.com-{ModifiedTo}_{Methodes.FixDateTimeFormt(str(datetime.now()))}{Format}')

    def ReturnQrImageName(ImageFormat):
        return Methodes.FixStrName(f'QrImage-{Methodes.FixDateTimeFormt(str(datetime.now()))}{ImageFormat}')

    def FixStrName(FileName):
        FileName = FileName.replace(':','-').replace('/','-').replace('\\','-').replace('|','-')
        FileName = FileName.replace('*','').replace('?','').replace('<','').replace('>','')
        return FileName

    def FixDateFormat(Date):
        Date = Date.replace(' ','_')
        return Date

    def SetDocFormat(Type):
        if(Type == 0):
            return ".rtf"
        elif(Type == 1):
            return ".docx"
        else:
            return ".docx"

    def FixDateTimeFormt(Input):
        Input = Input.replace(' ','_').replace('.','-')
        return Input

    def FixRequestFormat(Input):
        Input = Input.replace('-','\\')
        return Input.replace('/','\\')

    def ReverseRequestFormat(Input):
        return Input.replace('\\','-')

    def CreateDirectory(Path):
        try:
            if(os.path.isdir(Path) == False):
                os.mkdir(Path)
        except:
            pass