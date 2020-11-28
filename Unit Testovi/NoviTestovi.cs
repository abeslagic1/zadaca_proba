﻿using Kupid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    /*kreirana je klasa Recenzija1.
     * Ova klasa treba da sadrzi implementaciju metode DatjUtisak(), koja treba da vraca vrijednost "Pozitivan", ukoliko
     *zelimo da nam prodje definisani test.*/
  
    public class Recenzija1:IRecenzija
    {
       

        string IRecenzija.DajUtisak()
        {
            return "Pozitivan";
        }
    }


    [TestClass]
    public class NoviTestovi
    {
        #region Zamjenski Objekti

        [TestMethod]
        public void TestZamjenskiObjekti()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);

            Chat chat = new Chat(k1, k2);
            chat.DodajNovuPoruku(k1, k2, "volim te");
            Recenzija1 r = new Recenzija1();
            
            Komunikator k = new Komunikator();
            bool uspješnost = k.DaLiJeSpajanjeUspjesno(chat, r);

            Assert.IsTrue(uspješnost);
        }

        #endregion

        #region TDD

       [TestMethod]
        public void SpajanjeKorisnikaPoLokaciji()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 25, false);

            Komunikator k = new Komunikator();
            k.RadSaKorisnikom(k1, 0);
            k.RadSaKorisnikom(k2, 0);

            k.SpajanjeKorisnika();

            Assert.AreEqual(k.Razgovori.Count, 1);
        }
       
        [TestMethod]
        public void SpajanjeKorisnikaPoGodinama()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false);

            Komunikator k = new Komunikator();
            k.RadSaKorisnikom(k1, 0);
            k.RadSaKorisnikom(k2, 0);

            k.SpajanjeKorisnika();

            Assert.AreEqual(k.Razgovori.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SpajanjeKorisnikaIzuzetak()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 25, false);

            Komunikator k = new Komunikator();
            k.RadSaKorisnikom(k1, 0);
            k.RadSaKorisnikom(k2, 0);

            k.SpajanjeKorisnika();
        }

        [TestMethod]
        public void IzlistavanjeSvihPorukaSaSadrzajem1()
        {
            string sadrzaj = "sadrzaj";
            Komunikator k = new Komunikator();
            k.IzlistavanjeSvihPorukaSaSadržajem(sadrzaj);
            Assert.AreEqual(k.Razgovori.Count, 0);
        }

        [TestMethod]
        public void IzlistavanjeSvihPorukaSaSadrzajem2()
        {
            string sadrzaj1 = "matematika mi je bila omiljeni predmet";
            Komunikator k = new Komunikator();
            Korisnik korisnik1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false);
            Korisnik korisnik2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 25, false);
            Chat chat1 = new Chat(korisnik1,korisnik2);
            chat1.DodajNovuPoruku(korisnik1, korisnik2, sadrzaj1);
            List<Korisnik> prvaLista = new List<Korisnik>();
            prvaLista.Add(korisnik1);
            prvaLista.Add(korisnik2);
            string sadrzaj2 = "matematika mi nije bila omiljeni predmet";
            Korisnik korisnik3 = new Korisnik("user3", "user3*+", Lokacija.Sarajevo, Lokacija.Bihać, 25, false);
            Korisnik korisnik4 = new Korisnik("user4", "user4*+", Lokacija.Sarajevo, Lokacija.Bihać, 25, false);
            Chat chat2 = new Chat(korisnik3, korisnik4);
            chat2.DodajNovuPoruku(korisnik3,korisnik4,sadrzaj2);
            List<Korisnik> drugaLista = new List<Korisnik>();
            drugaLista.Add(korisnik3);
            drugaLista.Add(korisnik4);
            string sadrzaj3 = "fizika mi je bila draga";
            Korisnik korisnik5 = new Korisnik("user5", "user5*+", Lokacija.Sarajevo, Lokacija.Bihać, 25, false);
            Korisnik korisnik6 = new Korisnik("user6", "user6*+", Lokacija.Sarajevo, Lokacija.Bihać, 25, false);
            Chat chat3 = new Chat(korisnik5, korisnik6);
            chat3.DodajNovuPoruku(korisnik5, korisnik6, sadrzaj3);
            List<Korisnik> trecaLista = new List<Korisnik>();
            trecaLista.Add(korisnik5);
            trecaLista.Add(korisnik6);
            string sadrzaj = "matematika";
            k.RadSaKorisnikom(korisnik1, 0);
            k.RadSaKorisnikom(korisnik2, 0);
            k.RadSaKorisnikom(korisnik3, 0);
            k.RadSaKorisnikom(korisnik4, 0);
            k.RadSaKorisnikom(korisnik5, 0);
            k.RadSaKorisnikom(korisnik6, 0);
            k.Razgovori.Add(chat1);
            k.Razgovori.Add(chat2);
            k.Razgovori.Add(chat3);

            List<Poruka> rezultatFunckije = k.IzlistavanjeSvihPorukaSaSadržajem(sadrzaj);
            Assert.AreEqual(rezultatFunckije.Count,2);

        }

        #endregion
    }
}
