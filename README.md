# snake_2
Snake jegyzetből 2020 szept 02.

Megcsináltuk a Githubon a kódtárat, a VS-ben a Windows Dektop WPF (.NET Framework) solution-t
és feltöltjük azt a Github-ra


A View (MainWindow.xaml.cs) a megjelenítést, a billentyűleütések fogadását és továbbítását végzi.

A Model (ezt létre kell hozni) a billentyűparancsok alapján intézi a játékot
a Model általában egy folder, ami osztályokat tartalmaz, mi az Arena osztályt csináljuk most meg

Az Arena osztáylban csinálunk egy keyDown fgv-t, amit egy billentyű lenyomása hív meg:
	xaml-ben feliratkozunk a keydown eseményre, és ez a fgv hívja az arena.keyDown-t, és átadja neki paraméterként azt, hogy melyik gomb nyomódott le 

odáig jutottunk, hogy el tzdkjuk kapni a billentyűparancspokat és át tudjuk adni a Model-nek

most azt kell megoldani, hogy a Model-ből lássuk az xaml-t, azaz a képernyőre tudjunk írni:
	az xaml-ben példányosítottunk egy arena-t: arena = new Arena()
	de ezt megváltoztatjuk, úgy példányosítunbk, hogy átadjuk a MainWindow-t paraméterként: arena = new Arena(this)
	azonban nincs az Arena osztálynak egyparaméteres konstruktora, ezért ezt meg kell csinál(tat)ni (CTR.)
	így lett egy Mainwindow osztály, mainwindow paraméterünk az Arena osztályban
	hogy szebb legyen, ezt a mainWindow-ot átnevezzük View -nak

Most már a View paraméterrel hivatkozhatunk a képernyőnkre.

Az arena.keyDown fgv-be kísérletként beleírjuk, hogy indításkor jelenítse meg a kezdőszöveget a képernyőn, majd ha megnyomódott a nyíl, 
tüntesse azt el.

Az eredmény megjelenítéséhez ugyanúgy TextBlock-ot használunk, mint a játékszabályokhoz. Alapesetben hidden

Az arena.keyDown fgv-be beírjuk, hogy az első  nyílmegnyomáskor (amikor a játék elindul) váljon láthatóvá az eredmény

Elkészítettük a 20x20-as hálót a grid-ben

Letöltöttük a fontawesome-t (Nuget package) és a square outline icon-t minden egyes kockába beleraktuk

A játékszabályokat tartalmazó TextBlock-ot egy border-be foglaltuk, így az előrehozható a játéktér elé, ez a kezdő képernyő

Megcsináljuk a kígyó fejét:
	A View.ArenaGrid -beli elemeket a Children nevű gyűjtemény tartalmazza. Ez nullától indexelve van: View.ArenaGrid.Children[121]
	Ebben a gyűjteményben UIElement típusu elemk vannak, és csak ilyenek lehetnek. A fontawesome icon-jai viszont nem ilyenek. 
	Most kiveszünk egy elemet a gyűjterményből, és típuskonverzióval (illetve nem pontosan azzal) átalakítjuk, hogy elérjük az icon tulajdonságát
		ezután az Icon tulajdonságot már át tudjuk írni Circle-re


Ha a kígyó feje beleütközik a játéktér határába, a játék befejeződik

## Tárolni kell a pozicióját, és meg kell jeleníteni a kígyó testét


