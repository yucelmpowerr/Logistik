
--Tables 

CREATE DATABASE LojistikFirmasi;


CREATE TABLE Depo (
    Depo_ID INT PRIMARY KEY,
    Ad varchar(100) NOT NULL,
    Lokasyon varchar(300) NOT NULL,
	Gonderi_ID int Not NUll,
	Sube_ID int NOT NULL,
    FOREIGN KEY (Gonderi_ID) REFERENCES Gonderi(Gonderi_ID),
	FOREIGN KEY (Sube_ID) REFERENCES Þube(Depo_ID)
);

CREATE TABLE Gonderi (
    Gonderi_ID INT PRIMARY KEY,
    Siparis_ID int NOT NULL,
	Musteri_ID int NOT NULL,
	Arac_ID int NOT NULL,
	Durum varchar(100) NOT NULL,

	FOREIGN KEY (Arac_ID) REFERENCES Tasima_Araclari(Arac_ID),
	FOREIGN KEY (Musteri_ID) REFERENCES Musteri(Musteri_ID)
);


CREATE TABLE Kategoriler (
    Kategori_ID INT PRIMARY KEY,
    Ad varchar(50),
	FOREIGN KEY (Kategori_ID) REFERENCES Urun(Kategori_ID)
);


CREATE TABLE Loj_Merkez (
    Depo_ID INT PRIMARY KEY,
    Ad varchar(100) NOT NULL,
	Lokasyon varchar(300) NOT NULL,

	FOREIGN KEY (Depo_ID) REFERENCES Þube(Merkez_ID)
);

CREATE TABLE Musteri (
    Musteri_ID INT PRIMARY KEY,
	Ad varchar(50) NOT NULL,
	Soyad varchar(50) NOT NULL,
	Eposta varchar(200) NOT NULL,
	Telefon varchar(50) NOT NULL,
	Siparis_ID int,
	 
	FOREIGN KEY (Siparis_ID) REFERENCES Siparis(Siparis_ID)
);

CREATE TABLE Nakliye_Firmasi (

    Firma_ID INT PRIMARY KEY,
	Ad varchar(100) NOT NULL,
	Adres varchar(200) NOT NULL,
	Telefon varchar(20) NOT NULL,
	Gonderi_ID int,
	 
	FOREIGN KEY (Gonderi_ID) REFERENCES Gonderi(Gonderi_ID)
);


CREATE TABLE Personel (

    Personel_ID INT PRIMARY KEY,
	Ad varchar(50) NOT NULL,
	Soyad varchar(50) NOT NULL,
	Görev varchar(200) NOT NULL,
	Depo_ID int,
	 
	FOREIGN KEY (Depo_ID) REFERENCES Depo(Depo_ID)
);


CREATE TABLE Siparis (

    Siparis_ID INT PRIMARY KEY,
	Tarih varchar(50) NOT NULL,
	Musteri_ID int NOT NULL,
	Urun_ID int NOT NULL,
	Durum varchar(50),
	 
	FOREIGN KEY (Urun_ID) REFERENCES Urun(Urun_ID),
	FOREIGN KEY (Musteri_ID) REFERENCES Musteri(Musteri_ID)
);


CREATE TABLE Þube (
    Depo_ID INT PRIMARY KEY,
	Ad varchar(100) NOT NULL,
	Lokasyon varchar(300) NOT NULL,
	Merkez_ID int ,

	FOREIGN KEY (Merkez_ID) REFERENCES Loj_Merkez(Depo_ID),
);


CREATE TABLE Tasima_Araclari (

    Arac_ID INT PRIMARY KEY,
	Adý varchar(50),
	Kapasite varchar(50),
	Plaka_No varchar(20),
	Teslimat_Durumu varchar(50),
	 
	FOREIGN KEY (Arac_ID) REFERENCES Gonderi(Arac_ID),
);


CREATE TABLE TeslimatDurumu (

    Durum_ID INT PRIMARY KEY,
	Gonderi_ID INT NOT NULL,
	 
	FOREIGN KEY (Gonderi_ID) REFERENCES Gonderi(Gonderi_ID),
);


CREATE TABLE Urun (

    Urun_ID INT PRIMARY KEY,
	Ad varchar(80),
	Agýrlýk int,
	Kategori_ID int NOT NULL

	FOREIGN KEY (Kategori_ID) REFERENCES Kategoriler(Kategori_ID),
);


--Trigger
--Yeni bir kayýt eklendiðinde eklenen kayýta ait Gönderi tablosundaki 'Durum' deðerini 'Yolda' olarak deðiþtirir
CREATE TRIGGER TeslimatDurumuEklendiTrigger  
ON TeslimatDurumu  
AFTER INSERT  
AS BEGIN      
DECLARE @GonderiID INT;      
SELECT @GonderiID = Gonderi_ID FROM TeslimatDurumu;      
UPDATE Gonderi SET Durum = 'Yolda'      
WHERE Gonderi_ID = @GonderiID;  
END;


-- parametreli aggregate fonksiyonu
-- Bu fonksiyon çaðrýldýðýnda, en yüksek kapasiteli aracýn adý ve kapasitesi 'VehicleName' ve 'Capacity' sütunlarýyla birlikte döndürülür. 
CREATE FUNCTION EnYuksekKapasiteliArac
RETURNS @MaxCapacityTable TABLE (VehicleName varchar(100), Capacity int)
AS
BEGIN
    INSERT INTO @MaxCapacityTable (VehicleName, Capacity)
    SELECT TOP 1 Tasima_Araclari.Adý, CONVERT(INT, Kapasite) AS ConvertedCapacity
    FROM Tasima_Araclari
    ORDER BY CONVERT(INT, Kapasite) DESC;
    RETURN;
END;

--View
-- Teslim edilmiþ sipariþlere iliþkin bilgileri çeker.
CREATE VIEW TeslimEdilenSiparisler  
AS  
SELECT g.Siparis_ID, m.Ad as Musteri_Adi,u.Ad as Urun_Adi, g.Durum  
FROM Gonderi g  JOIN Siparis s ON s.Siparis_ID = g.Siparis_ID  
JOIN Urun u On s.Urun_ID = s.Urun_ID  --joinle tablolarý birleþtiririz
JOIN Musteri m ON g.Musteri_ID = m.Musteri_ID  
Where g.Durum = 'Teslim Edildi';


-- Kursor (c# kullanabilmek için PROCEDURE olarak yazýldý)
-- her bir 'Teslim Edildi' durumunu bulduðunda, bu durumdaki kayýtlarýn sayýsýný birer birer artýrarak @TeslimEdilenCount deðiþkenine ekler. Sonuç olarak, prosedür TeslimEdilenGonderiSayisi olarak adlandýrýlan deðiþkeni döndürür.
CREATE PROCEDURE GetTeslimEdilenGonderiSayisi  
AS  BEGIN      
DECLARE @TeslimEdilenCount INT      
SET @TeslimEdilenCount = 0        
DECLARE @Durum NVARCHAR(50)        
DECLARE countCursor -- kursoru baþlatýyorr do while gibi çalýþýyor mantýgý ayný 
CURSOR FOR      
SELECT Durum FROM Gonderi      
WHERE Durum = 'Teslim Edildi'        
OPEN countCursor        
FETCH NEXT FROM countCursor INTO @Durum WHILE @@FETCH_STATUS = 0      
BEGIN       
SET @TeslimEdilenCount = @TeslimEdilenCount + 1          --kursor do while döngðsð gibi tek tek verileri gezip durumu teslim edildiyse 1 arttýrýýtoyr
FETCH NEXT FROM countCursor INTO @Durum      --eþitlik durumu
END        
CLOSE countCursor      
DEALLOCATE countCursor      --k  
SELECT @TeslimEdilenCount AS TeslimEdilenGonderiSayisi  
END 

--PROCEDURE
--Belirli bir Arac_ID deðerine sahip olan bir aracý Tasima_Araclari tablosundan silmek için kullanýlýr.
CREATE PROCEDURE AracKaldýr      
@Arac_ID INT  
AS  
BEGIN      
DELETE FROM Tasima_Araclari      
WHERE Arac_ID = @Arac_ID;  
END;



--PROCEDURE
--Tasima_Araclari tablosundandaki tüm araçlarý çekmek için kullanýlýr.
CREATE PROCEDURE TumAraclar  
AS  
BEGIN      
SELECT * FROM Tasima_Araclari;    
END;

--PROCEDURE
--Belirli bir Arac_ID'ye sahip aracýn bilgilerini güncellemek için kullanýlýr.
CREATE PROCEDURE AracGuncelle      
@Arac_ID INT,   
@Adý varchar(50),   
@Kapasite varchar(50),      
@PlakaNo varchar(20)  
AS  
BEGIN      
UPDATE Tasima_Araclari      
SET Kapasite = @Kapasite, Plaka_No = @PlakaNo, Adý = @Adý      
WHERE Arac_ID = @Arac_ID;  
END;


--PROCEDURE
--Tasima_Araclari tablosuna yeni bir araç eklemek için kullanýlýr.
CREATE PROCEDURE AracEkle      
@Kapasite varchar(50),      
@PlakaNo varchar(20),   
@Adý varchar(50)  
AS  
BEGIN      
INSERT INTO Tasima_Araclari(Adý,Kapasite, Plaka_No) VALUES (@Adý,@Kapasite, @PlakaNo); 
END;


--PROCEDURE
--Depo, Þube ve Loj_Merkez tablolarýný birleþtirerek bu tablolardan gereli verileri çekmek için kullanýlýr
CREATE PROCEDURE SelectDepoSubeMerkez
AS  
BEGIN   
SELECT Depo.Depo_ID, Depo.Ad AS DepoName, Þube.Ad as SubeName, Loj_Merkez.Ad AS MerkezName,Þube.Lokasyon AS ÞubeLok , Loj_Merkez.Lokasyon AS MerkezLok,Depo.Lokasyon AS DepoLok    
FROM Depo   
INNER JOIN Þube ON Depo.Sube_ID = Þube.Depo_ID   --tablolarý içine ekleme inner
INNER JOIN Loj_Merkez ON Þube.Merkez_ID = Loj_Merkez.Depo_ID;  
END;


