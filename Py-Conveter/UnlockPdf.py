import pikepdf
from AppliedMethodes import Methodes
from datetime import datetime
import os

def TUnlockPdf(InputFilePath,InputFileName,OutputPath,UserIp):
    PWDFilePath='./PWD'
    PWDFileName='/top-pwd.txt'
    if(InputFilePath,InputFileName,OutputPath,UserIp != None):
        outFileName= Methodes.ReturnFileNameWithoutModifie('.pdf','Unlock-Pdf')
        OutputPath = f'{Methodes.FixRequestFormat(OutputPath)}\\{UserIp}'
        InputFile = f'{Methodes.FixRequestFormat(InputFilePath)}\\{InputFileName}'

        if(PWDFilePath != None and PWDFilePath != ''):
            PWDFullPath = f'{Methodes.FixRequestFormat(PWDFilePath)}\\{PWDFileName}'
            passlist = ReadPWD(PWDFullPath)
        else:
            passlist = None
        if(type(passlist) != dict ):
            return TryToUnlock(passlist,InputFile,OutputPath,outFileName)
        else:
            return passlist
    else:
        return {'Success':False,'Message':'Error Input Cannot Be null'}

def ReadPWD(PWDFullPath):
    passlist=[]
    cv=0
    try:
        if(PWDFullPath != None and PWDFullPath != ''):
            file = open(PWDFullPath,'r')
        else:
            file = open('Top-PWD.txt','r')
        data = file.readlines()
        for i in data:
            cv+=1
            if(cv <= 3000):
                passlist.append(i.replace('\n',''))
            else:
                break
        return passlist
    except:
        return {'Success':False,'Message':' Your PassWd Not Currect'}

def TryToUnlock(passlist,InputFile,OutputPath,OutFileName,):
    unlock =False
    found=''
    start = datetime.now()
    for i in passlist:
        try:
            if(i != None and i != '' and i != ' '):
                # Check PassList On File
                pdf = pikepdf.open(InputFile,allow_overwriting_input=True,password=i)
                try:
                    Methodes.CreateDirectory(OutputPath)
                    #Try To Save Output
                    pdf.save(f'{OutputPath}\\{OutFileName}')
                    found=i
                    end =datetime.now()
                    unlock= True
                    break
                except:
                    return {'Success':False,'Message':'Error In Proccess'}
        except:
            pass
    if(unlock):
        return {'Success':True,'Message':'The file was successfully decrypted','Password':found,'ProcessTime':'{}'.format(end - start),'OutFile':OutFileName,'OutPath':Methodes.ReverseRequestFormat(OutputPath)}
    else:
        return {'Success':False,'Message':'''Sorry, we were unable to decrypt your file.
We can decrypt a lot of files, but this one has a fairly good password and takes a lot of time compared to the available features.'''}


#TUnlockPdf('top-pdw.txt','E:\\C\\Input','ggtest2.pdf','E:\\C\\Output','192.168.123')   
