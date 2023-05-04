import os
import shutil
import requests
import urllib.parse
from AppliedMethodes import Methodes


class Program:
    def __init__():
        pass

    def GenerateQr(DestUrl,OutputPath,UserIp):
        if(DestUrl,OutputPath,UserIp != None):
            
            Url = f"https://qrickit.com/api/qr.php?d={urllib.parse.quote_plus(DestUrl)}"
            OutPath=f"{Methodes.FixRequestFormat(OutputPath)}\\{UserIp}"
            FileName =list({Methodes.ReturnQrImageName('.png')})
            Methodes.CreateDirectory(OutPath)
            try:
                response = requests.get(Url, stream=True)
                with open(f"{OutPath}\\{FileName[0]}", 'wb') as out_file:
                    shutil.copyfileobj(response.raw, out_file)
                del response
                return {'Success':True,'Message':'QrImageMaked','OutFile':FileName[0],'OutPath':Methodes.ReverseRequestFormat(OutPath)}
            except:
                return {'Success':False,'Message':'Bad Request'}
        else:
            return {'Success':False,'Message':'Error Input Cannot Be null'}

    def LinkShorter(LongUrl):
        pass
