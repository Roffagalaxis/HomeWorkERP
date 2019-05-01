 insert into TermekekSet(neve, leiras) values ('Drágaköves Nyaklánc', 'Alkamli használatra');
 insert into TermekekSet(neve, leiras) values ('Opálköves Füllbevaló', 'Hétköznapi használatra');
 insert into TermekekSet(neve, leiras) values ('Féldrágaköves Nyaklánc', 'Egyedi Rendelésre');
 insert into TermekekSet(neve, leiras) values ('Fehérarany Gyűrű', 'Esküvőre');
 insert into TermekekSet(neve, leiras) values ('RoseGold Gyűrű', 'Valentin Napra');
 insert into TermekekSet(neve, leiras) values ('Ezüst Karperec', 'Antik Mintázatú');
 insert into TermekekSet(neve, leiras) values ('Karlánc', 'Fémötvözetből'); 	
 insert into TermekekSet(neve, leiras) values ('Kövekek', 'dkg');
 insert into TermekekSet(neve, leiras) values ('Ragasztó', 'Tubus');
--
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('AA1', 1, 3);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('BB1', 2, 2);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('CC1', 3, 3);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('DD1', 4, 1);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('EE1', 5, 2);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('FF1', 6, 2);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('GG1', 7, 2);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('AA2', 1, 3);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('BB2', 2, 3);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('CC2', 3, 3);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('AA3', 1, 3);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('AA4', 1, 1);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('FF2', 6, 3);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('FF3', 6, 2);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('FF4', 6, 2);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('FF5', 6, 2);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('FF6', 6, 2);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('EE3', 5, 3);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('BB3', 1, 3);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('AA5', 6, 2);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('BB4', 1, 1);
 insert into SzeriaszamokSet(szeriaszam, termekek_id, statusz) values ('AA6', 6, 2); 	
--
 insert into PolcokSet(nev, szint, doboz) values ('BAL', '1', 'A');
 insert into PolcokSet(nev, szint, doboz) values ('BAL', '1', 'B');
 insert into PolcokSet(nev, szint, doboz) values ('BAL', '2', 'A');
 insert into PolcokSet(nev, szint, doboz) values ('BAL', '2', 'B');
 insert into PolcokSet(nev, szint, doboz) values ('JOBB', '1', 'A');
 insert into PolcokSet(nev, szint, doboz) values ('JOBB', '1', 'B');
 insert into PolcokSet(nev, szint, doboz) values ('JOBB', '2', 'A');
 insert into PolcokSet(nev, szint, doboz) values ('JOBB', '2', 'B');
 insert into PolcokSet(nev, szint, doboz) values ('JOBB', '3', 'A');
 insert into PolcokSet(nev, szint, doboz) values ('JOBB', '4', 'A');
--
 insert into KeszletSet(termekek_id, szeriaszamok_id, polcok_id, mennyiseg) values (8,NULL, 2, 20);
 insert into KeszletSet(termekek_id, szeriaszamok_id, polcok_id, mennyiseg) values (9,NULL, 1, 10);
 insert into KeszletSet(termekek_id, szeriaszamok_id, polcok_id, mennyiseg) values (2, 2, 4, 1);
 insert into KeszletSet(termekek_id, szeriaszamok_id, polcok_id, mennyiseg) values (5,5, 6, 1);
 insert into KeszletSet(termekek_id, szeriaszamok_id, polcok_id, mennyiseg) values (6,6, 5, 1);
 insert into KeszletSet(termekek_id, szeriaszamok_id, polcok_id, mennyiseg) values (7,7, 10, 1);
 insert into KeszletSet(termekek_id, szeriaszamok_id, polcok_id, mennyiseg) values (6,14, 9, 1);
 insert into KeszletSet(termekek_id, szeriaszamok_id, polcok_id, mennyiseg) values (6,15, 9, 1);
 insert into KeszletSet(termekek_id, szeriaszamok_id, polcok_id, mennyiseg) values (6,16, 9, 1);
 insert into KeszletSet(termekek_id, szeriaszamok_id, polcok_id, mennyiseg) values (6,17, 9, 1);
 insert into KeszletSet(termekek_id, szeriaszamok_id, polcok_id, mennyiseg) values (1,20, 3, 1);
 insert into KeszletSet(termekek_id, szeriaszamok_id, polcok_id, mennyiseg) values (1,22, 3, 1);
--
 Insert into UsersSet (Name, Password) values ('Admin', 'Admin2');