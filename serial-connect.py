import tkinter as tk
from tkinter import ttk
import serial
import pyodbc
import time
import datetime
from datetime import date
from datetime import datetime
today = date.today()

login= tk.Tk()
login['bg']="#b3daec"
login.geometry('325x95')  
login.title('Giriş yap')
login.iconbitmap("technopc-logo-png-6858-d.ico")
usernameLabel = tk.Label(login, text="Kullanıcı adı",bg="#b3daec")
usernameLabel.grid(row=0, column=0)
username = tk.StringVar()
usernameEntry = tk.Entry(login, width=40, textvariable=username)
usernameEntry.grid(row=0, column=1)
passwordLabel = tk.Label(login,text="Şifre",bg="#b3daec")
passwordLabel.grid(row=1, column=0) 
password = tk.StringVar()
passwordEntry = tk.Entry(login, textvariable=password, show='*',width=40)
passwordEntry.grid(row=1, column=1)
#kullanici_value= tk.StringVar()
#kullanici=kullanici_value.set(username.get)


server = 'localhost' 
database = 'SaglikTreyleri'
cnxn = pyodbc.connect('Driver={SQL Server};'
                      'Server=localhost;'
                      'Database=SaglikTreyleri;'
                      'Trusted_Connection=yes;')
cursor = cnxn.cursor()
exceptionWrong = tk.Label(login,text="      Kullanıcı adı ya da şifre yanlış",bg="#b3daec")

def validateLogin(username, password):
    cursor.execute("SELECT * FROM kullanicilar")
    myresult = cursor.fetchall()
    for rows in myresult:
        exceptionWrong.grid_remove()
        if (username==rows[0] and password==rows[1]):
            usernameLabel.grid_remove()
            usernameEntry.grid_remove()
            passwordLabel.grid_remove()
            passwordEntry.grid_remove()
            loginButton.grid_remove()
            #window.deiconify()
            button = tk.Button(login,text="1.çekmece ",width=27,height=4,fg="black",command=lambda:connect(username))
            button.grid(row=0,column=0,sticky=tk.NS)
            button2 = tk.Button(login,text="2.çekmece ",width=27, height=4,fg="black",command=lambda:connect2(username))
            button2.grid(row=1,column=0,sticky=tk.NS)
            button3 = tk.Button(login,text="3.çekmece ",width=27,height=4,fg="black",command=lambda:connect3(username))
            button3.grid(row=2,column=0,sticky=tk.NS)
            button4 = tk.Button(login,text="4.çekmece ",width=27,height=4,fg="black",command=lambda:connect4(username))
            button4.grid(row=3,column=0,sticky=tk.NS)
            button5 = tk.Button(login,text="5.çekmece ",width=27,height=4,fg="black",command=lambda:connect5(username))
            button5.grid(row=4,column=0,sticky=tk.NS)
            login.geometry('200x360')  #check
            login.title('Çekmeceler')
             #exede açılacak mı bak
            break
        else:
            login.geometry('325x130')
            exceptionWrong.grid(row=5,column=1,rowspan=2)
            usernameEntry.delete(0, tk.END)
            passwordEntry.delete(0, tk.END)
    def connect(username): #fonksyionlar düzenlenebilir
            pump = serial.Serial(port='COM3', baudrate=115200)
            pump.write(b'from machine import Pin\r\n')
            pump.write(b'cekmece1 = Pin(18, Pin.OUT)\r\n')
            pump.write(b'cekmece1.value(1)\r\n')
            time.sleep(1)
            pump.write(b'cekmece1.value(0)\r\n')
            time.sleep(1)
            pump.write(b'cekmece1.value(1)\r\n')
            now = datetime.now()
            tarih= today.strftime("%Y/%m/%d")
            saat= now.strftime("%H:%M:%S")
            cekmece="1"
            cursor.execute("INSERT INTO logKayit_ (tarih, saat, cekmece, kullanici) values(?,?,?,?)", (tarih,saat,cekmece,username))
            cnxn.commit()
    def connect2(username):
            pump = serial.Serial(port='COM3', baudrate=115200)
            pump.write(b'from machine import Pin\r\n')
            pump.write(b'cekmece2 = Pin(18, Pin.OUT)\r\n')
            pump.write(b'cekmece2.value(1)\r\n')
            time.sleep(1)
            pump.write(b'cekmece2.value(0)\r\n')
            time.sleep(1)
            pump.write(b'cekmece2.value(1)\r\n')
            now = datetime.now()
            tarih= today.strftime("%Y/%m/%d")
            saat= now.strftime("%H:%M:%S")
            cekmece="2"
            cursor.execute("INSERT INTO logKayit_ (tarih, saat, cekmece, kullanici) values(?,?,?,?)", (tarih,saat,cekmece,username))
            cnxn.commit()
    def connect3(username):
            pump = serial.Serial(port='COM3', baudrate=115200)
            pump.write(b'from machine import Pin\r\n')
            pump.write(b'cekmece3 = Pin(18, Pin.OUT)\r\n')
            pump.write(b'cekmece3.value(1)\r\n')
            time.sleep(1)
            pump.write(b'cekmece3.value(0)\r\n')
            time.sleep(1)
            pump.write(b'cekmece3.value(1)\r\n')
            now = datetime.now()
            tarih= today.strftime("%Y/%m/%d")
            saat= now.strftime("%H:%M:%S")
            cekmece="3"
            cursor.execute("INSERT INTO logKayit_ (tarih, saat, cekmece, kullanici) values(?,?,?,?)", (tarih,saat,cekmece,username))
            cnxn.commit()
    def connect4(username):
            pump = serial.Serial(port='COM3', baudrate=115200)
            pump.write(b'from machine import Pin\r\n')
            pump.write(b'cekmece4 = Pin(18, Pin.OUT)\r\n')
            pump.write(b'cekmece4.value(1)\r\n')
            time.sleep(1)
            pump.write(b'cekmece4.value(0)\r\n')
            time.sleep(1)
            pump.write(b'cekmece4.value(1)\r\n')
            now = datetime.now()
            tarih= today.strftime("%Y/%m/%d")
            saat= now.strftime("%H:%M:%S")
            cekmece="4"
            cursor.execute("INSERT INTO logKayit_ (tarih, saat, cekmece, kullanici) values(?,?,?,?)", (tarih,saat,cekmece,username))
            cnxn.commit()
    def connect5(username):
            pump = serial.Serial(port='COM3', baudrate=115200)
            pump.write(b'from machine import Pin\r\n')
            pump.write(b'cekmece5 = Pin(18, Pin.OUT)\r\n')
            pump.write(b'cekmece5.value(1)\r\n')
            time.sleep(1)
            pump.write(b'cekmece5.value(0)\r\n')
            time.sleep(1)
            pump.write(b'cekmece5.value(1)\r\n')
            now = datetime.now()
            tarih= today.strftime("%Y/%m/%d")
            saat= now.strftime("%H:%M:%S")
            cekmece="5"
            cursor.execute("INSERT INTO logKayit_ (tarih, saat, cekmece, kullanici) values(?,?,?,?)", (tarih,saat,cekmece,username))
            cnxn.commit()
            #print(username)
            #return username            
loginButton = tk.Button(login, text="Giriş yap", bg="#0083c0",fg="white",font='Helvetica 8 bold', command=lambda: validateLogin(username.get(),password.get()))
loginButton.grid(row=4, column=0,padx=15,pady=15,columnspan=2)
login.mainloop()


