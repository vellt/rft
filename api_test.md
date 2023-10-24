# API teszt POSTMAN által

A végpontontok több esetet is biztosítanak tesztelésre, hiszen vannak olyan adatok melyeket csak azon felhasználók módosíthatnak, akiknek a szerepkörük "teacher" vagy "admin", mindeki más esetében meg kell tagadnia az API-nak a kérés lefutását!

## Az alábbi útvonalak vannak a projektben

![image](https://github.com/vellt/rft/assets/61885011/0b0b2cf6-65f0-4c84-bd0f-e0d17b055e19)

<hr>

## tesztelt esetek

<table>
  <tr>
    <td>
      Vizsga &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp
    </td>
    <td>
      Vizsga regisztráció &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp
    </td>
    <td>
      Felhasználó &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp
    </td>
  </tr>
  <tr>
    <td>
      <p> Vizsgák lekérése </p> 
      <p> Vizsga készítése tanár-/adminként </p>
      <p> Vizsga készítése diákként </p>
      <p> Vizsga módosítása tanár-/adminként </p>
      <p> Vizsga módosítása diákként </p>
      <p> Vizsga törlése tanár-/adminként </p>
      <p> Vizsga törlése diákként </p>
    </td>
    <td>
      <p> Vizsgára való regsztrálás tanár-/adminként</p>
      <p> Vizsgára való regsztrálás diákként </p>
      <p> Vizsga regisztráció törlése tanár-/adminként</p>
      <p> Vizsga regisztráció törlése diákként</p>
      <p> Vizsga regisztrációk legérése</p>
    </td>
    <td>
      <p> Felhasználók lekérdezése</p>
    </td>
  </tr>
</table>






<hr>

# vizsga

## Vizsgák lekérése
nincs semmilyen megkötés vele szemben, akárki meghívhatja [tanár, admin, diák]:

![image](https://github.com/vellt/rft/assets/61885011/bdb1e366-f785-4f17-9853-8bc691961668)

## Vizsga készítése tanár-/adminként
Vizsga készítése ezesetben lehetséges, hiszen a követelményeknek megfelel:

![image](https://github.com/vellt/rft/assets/61885011/29c431dd-aeb3-41ec-959c-95a17f78947d)

## Vizsga készítése diákként
Ezesetben vissza kell utasítania a kérést az API-nak, hiszen ehhez egy diáknak nem szabad hozzáférnie

![image](https://github.com/vellt/rft/assets/61885011/7eb42217-1299-4dff-8cc1-6da91f53687a)

## Vizsga módosítása tanár-/adminként
Vizsga módosítása ezesetben lehetséges, hiszen a követelményeknek megfelel:

![image](https://github.com/vellt/rft/assets/61885011/0d4896af-7a99-40e7-a827-999c440dc6f0)

## Vizsga módosítása diákként
Ezesetben vissza kell utasítania a kérést az API-nak, hiszen ehhez egy diáknak nem szabad hozzáférnie

![image](https://github.com/vellt/rft/assets/61885011/941b5f22-384d-468e-be15-85a0060c6bc9)

## Vizsga törlése diákként
Ezesetben vissza kell utasítania a kérést az API-nak, hiszen ehhez egy diáknak nem szabad hozzáférnie

![image](https://github.com/vellt/rft/assets/61885011/de8fe6fc-03fd-413d-a272-63ab7ecbdf8b)

## Vizsga törlése tanár-/adminként
Vizsga törlése ezesetben lehetséges, hiszen a követelményeknek megfelel:

![image](https://github.com/vellt/rft/assets/61885011/cd203d04-03ce-45f6-a614-73507db47742)

<hr>

# Vizsga regisztráció

## Vizsgára való regsztrálás tanár-/adminként
API válasza "hozzáférés megtagadva", hiszen csak tanulók férhetnek ehhez a végponthoz

![image](https://github.com/vellt/rft/assets/61885011/2b86df3c-1e0a-4ebb-affe-6b33fd2cc485)

## Vizsgára való regsztrálás diákként
Diákként már engedi a belépést a vizsgára, és a response-ban pedig visszatér az adott vizsga adataival

![image](https://github.com/vellt/rft/assets/61885011/c9ddedaa-5e9f-4e77-b737-533a84f7549c)

## Vizsga regisztráció törlése tanár-/adminként vagy a készítő id-jától eltérő diákként
Azesetben ha nem az a diák törli a vizsgára történt jelentkezést, aki ezt felvette, akkor azt értelemszerűen el kell utasítania az API-nak.

![image](https://github.com/vellt/rft/assets/61885011/39d38aca-e5d6-4ee0-a85d-be91923eaed2)

## Vizsga regisztráció törlése diákként
Vizsgára való jelentekzés törlése ezesetben lehetséges, hiszen a követelményeknek megfelel.

![image](https://github.com/vellt/rft/assets/61885011/fbfcd467-a61b-4b8d-9649-d37df0fecf83)

## Vizsga regisztrációk legérése
nincs semmilyen megkötés vele szemben, akárki meghívhatja [tanár, admin, diák]:

![image](https://github.com/vellt/rft/assets/61885011/84120720-9318-4563-acb8-5153cb66c5ba)


<hr>

# Felhasználó

## Felhasználók lekérdezése
nincs semmilyen megkötés vele szemben, akárki meghívhatja [tanár, admin, diák]:

![image](https://github.com/vellt/rft/assets/61885011/3c54ac07-2974-4046-a544-606ed989e1e9)
