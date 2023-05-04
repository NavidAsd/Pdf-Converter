from cv2 import CV_16U
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.keys import Keys
from subprocess import call
from selenium.webdriver.support.ui import Select

urllist =['https://spys.one/free-proxy-list/RU/','https://spys.one/free-proxy-list/BD/','https://spys.one/free-proxy-list/IN/','https://spys.one/free-proxy-list/SG/','https://spys.one/free-proxy-list/FR/']

class Program():
    def __init__(self,cv):
        self.cv=cv
        self.option = webdriver.ChromeOptions()


    #region ObjectFinder       
    def WaitForObject(self,type,string):
        return WebDriverWait(self.driver,9).until(EC.presence_of_element_located((type,string)))

    def WaitForObjects(self,type,string):
        return WebDriverWait(self.driver,4).until(EC.presence_of_all_elements_located((type,string))) 
    #endregion


    def Start(self):
        self.option = webdriver.ChromeOptions()
        # For older ChromeDriver under version 79.0.3945.16
        self.option.add_experimental_option("excludeSwitches", ["enable-automation"])
        self.option.add_experimental_option('useAutomationExtension', False)
        self.option.headless = True
        self.option.add_argument("start-maximized")
        self.option.add_experimental_option("excludeSwitches", ["enable-automation"])
        self.option.add_experimental_option('useAutomationExtension', False)
        self.option.add_argument("window-size=1280,800")
        self.option.add_argument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36")
        #..#
        self.driver=webdriver.Chrome(executable_path="chromedriver.exe",options=self.option)
        self.driver.get(urllist[self.cv])
        bot.GetData()

    def GetData(self):
        outlist =[]
        select = Select(self.driver.find_element_by_id('xpp'))
        # select by value 
        select.select_by_value('5')
        listt = self.driver.find_elements_by_class_name("spy14")
        for i in listt:
            if(i.text.find(":") >= 0 and i.text.find(".") >= 1 ):
                outlist.append(i.text)
        bot.writeproxies(outlist)

    def writeproxies(self,outlist):
        try:
            oldtext = open("proxies.txt",'r')
            old = oldtext.readlines()
        except:
            pass
        file = open("proxies.txt","w")
        
        for i in outlist:
            file.write(i)
            file.write('\n')
        try:
            for j in old:
                file.write(j)
        except:
            pass

        file.close()
        bot.changeurl()
   
    def changeurl(self):
        if(self.cv < len(urllist)-1):
            self.cv+=1
            self.driver.get(urllist[self.cv])
            bot.GetData()
        else:
            self.driver.quit()
            exit()
            pass

bot = Program(0)
bot.Start()