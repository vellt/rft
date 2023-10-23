# Dokumentáció

A leírás alapján elkezdtük megtervezni az adatbázist. Ahol rögzítésre kerültek a főbb táblák (User, Exam, Register), és a hozzájuk tartozó főbb mezők is. Az API-nak tudnia kellett lekezelni különböző hozzáféréseket. Pl csak olyan felhasználók hozhatnak létre/törölhetnek/módosíthatnak vizsgákat, akik szerepköre „admin” vagy „teacher”. További megszorítás volt, hogy csak azok regisztrálhatnak vizsgára vagy törölhetik ezen regisztrációjukat, akik szerepköre „student”. 
Ezekre ügyelve alakítottuk ki az alábbi adatbázist, adatszerkezetet.
<br>

![KÉP1](https://github.com/vellt/rft/assets/61885011/df6773f4-7716-42e9-b416-96aa5331e029)

A projekt kivitelezéséhez mi a .NET Core alapú ASP.NET Web API keretrendszert használtuk. Adatbázishoz pedig egy lokális adatbázist, az Sqlite-ot használtuk. Melyet a folyamatosan fejlesztett Web API-val, illetve a „DB Browser for SQLite” alkalmazással manipuláltunk. A projekt Entity Framework-öt használ, abból is a code first szemlélettel alakítottuk ki az adatbáziskapcsolatot. Így SQL parancs nélkül tudjuk az adatokat szerkeszteni az adatbázisban. Felgyorsította a munkafolyamatot. Unit teszthez pedig egy MSTest-et hoztunk létre, ahol a Moq könyvtár használatával végeztünk el több teszt esetet az ExamsController osztályhoz.

Útvonalak (Route-ok) kialakításakor csak a legfontosabb végpontokat vettük figyelembe:
<br>

![KÉP2](https://github.com/vellt/rft/assets/61885011/3efcc44c-fa19-406f-a17d-05c79173c1a2)
