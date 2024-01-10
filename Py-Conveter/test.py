import localfitz
from AppliedMethodes import Methodes
InputFileName = 'imgg.pdf'
OutputPath='ggg'
outfilename=Methodes.ReturnFileNameWithoutModifie('.zip','ExtractImages_Compressed')
start = localfitz.Extract(Outpath=OutputPath,Filename=InputFileName)
rs = start.loop()
result = Methodes.CompressFilesToZip(start.imgFnamelist,OutputPath,outfilename)
