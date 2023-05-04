import Converter
import UnlockPdf
from flask import *
import datetime
from threading import Thread
import QrCodeMaker 

app = Flask(__name__)
app.config["DEBUG"] = True

@app.route('/PdfToPpt/', methods=['GET'])
def PdfToPpt():
    try:
        response = Converter.Program.PdfToPpt(request.args.get('InputFilePath'), request.args.get('InputFileName'), request.args.get('OutputPath'), request.args.get('UserIp'))
        return jsonify(response)
    except:
        response = {'Success':False,'Message':'Error Input Cannot Be null'}
        return jsonify(response)

@app.route('/XlsxToPdf/',methods=["GET"])
def XlsxToPdf():
    try:
        response =  Converter.Program.ExcelToPdf(request.args.get('InputFilePath'), request.args.get('InputFileName'), request.args.get('OutputPath'), request.args.get('UserIp'))
        return jsonify(response)
    except:
        response = {'Success':False,'Message':'Error Input Cannot Be null'}
        return jsonify(response)

@app.route('/PptToPdf/',methods=['GET'])
def PptToPdf():
    try:
        response =  Converter.Program.PptToPdf(request.args.get('InputFilePath'), request.args.get('InputFileName'), request.args.get('OutputPath'), request.args.get('UserIp'))
        return jsonify(response)
    except:
        response = {'Success':False,'Message':'Error Input Cannot Be null'}
        return jsonify(response)

@app.route('/PdfToDoc/',methods=['GET'])
def PdfToDoc():
    try:
        response =  Converter.Program.PdfToWord(request.args.get('InputFilePath'), request.args.get('InputFileName'), request.args.get('OutputPath'), request.args.get('UserIp'),request.args.get('FormatType'))
        return jsonify(response)
    except:
        response = {'Success':False,'Message':'Error Input Cannot Be null'}
        return jsonify(response)



@app.route('/DocToPdf/',methods=['GET'])
def DocToPdf():
    try:
        response =  Converter.Program.WordToPdf(request.args.get('InputFilePath'), request.args.get('InputFileName'), request.args.get('OutputPath'), request.args.get('UserIp'))
        return jsonify(response)
    except:
        response = {'Success':False,'Message':'Error Input Cannot Be null'}
        return jsonify(response)

@app.route('/UnllockPdf/',methods=['GET'])
def UnllockPdf():
    try:
        response =  UnlockPdf.TUnlockPdf(request.args.get('InputFilePath'), request.args.get('InputFileName'), request.args.get('OutputPath'), request.args.get('UserIp'))
        return jsonify(response)
    except:
        response = {'Success':False,'Message':'Error Input Cannot Be null'}
        return jsonify(response)

@app.route('/ExtractImages/',methods=['GET'])
def ExtractImages():
    try:
        response =  Converter.Program.ExtractPdfImages(request.args.get('InputFilePath'), request.args.get('InputFileName'), request.args.get('OutputPath'), request.args.get('UserIp'))
        return jsonify(response)
    except:
        response = {'Success':False,'Message':'Error Input Cannot Be null'}
        return jsonify(response)

@app.route('/QrMaker/',methods=['GET'])
def QrMaker():
    try:
        response = QrCodeMaker.Program.GenerateQr(request.args.get('DestUrl'), request.args.get('OutputPath'), request.args.get('UserIp'))
        return jsonify(response)
    except:
        response = {'Success':False,'Message':'Error Input Cannot Be null'}
        return jsonify(response)


print(f'Running at: {datetime.datetime.now()}')
print()
    
from waitress import serve
serve(app, host="127.0.0.1", port=5050)