#!/bin/bash
#--------------------
#Zmienne

loop=1
newPassword=
#--------------------
#Funkcje główne

function menu
{
echo "*-----------------------*"
echo "*          MENU         *"
echo "*-----------------------*"
echo "*                       *"
echo "*   1)  Users Manager   *"   
echo "*   2)  Group Manager   *"
echo "*   3)  File Manager    *"
echo "*   4)  Info o Systemie *"
echo "*   0)  EXIT            *"
echo "*                       *"
echo "*-----------------------*"
 read -rsn1 -p "Wybierz numer zadania . . ." x; echo
sleep 0.2
case "$x" in
 "1") zadanie1 ;;
 "2") zadanie2 ;; 
 "3") zadanie3 ;;
 "4") zadanie4 ;;
 "0") wyjscie ;;
 *) echo "Zły wybór. Wybierz jeszcze raz."; sleep 3 ;;
esac 

clear
}

#------------------------------------------------------------------------

function zadanie1
{
while [ $loop -le 8 ] ; do
clear
echo "*-------------------------*"
echo "*       User_Menager      *"
echo "*-------------------------*"
echo "*                         *"
echo "*       1) Lista          *"
echo "*       2) Dodanie        *"
echo "*       3) Usunięcie      *"
echo "*       4) Modyfikacja    *"
echo "*       0) Powrót         *"
echo "*                         *"
echo "*-------------------------*"
read -rsn1 -p "Wybierz numer zadania" z1Wybor ; echo 
clear
case $z1Wybor in
"1") cut -d : -f 1 /etc/passwd ; read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . ." ; echo ;;
"2") echo "Wpisz nazwę użytkownika którego chcesz dodać i naciśnij ENTER : " ; read user ; sudo useradd  $user ; echo "użytkownik dodany"; break ;;
"3") delUser ; break ;;
"4") modUsers ; break ;; 
"0") break ;;
*) echo "zły wybór" ; continue ;;
esac 

done
 }

#------------------------------------------------------------------------

function zadanie2
{
while [ $loop -le 8 ] ; do
clear
echo "*-------------------------*"
echo "*      Group_Menager      *"
echo "*-------------------------*"
echo "*                         *"
echo "*       1) Lista Grup     *"
echo "*       2) Dodanie        *"
echo "*       3) Usunięcie      *"
echo "*       4) Modyfikacja    *"
echo "*       0) Powrót         *"
echo "*                         *"
echo "*-------------------------*"
read -rsn1 -p "Wybierz numer zadania" z2Wybor ; echo 
clear
case $z2Wybor in
"1") cut -d : -f 1 /etc/group ; read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . ." ; echo ;; 
"2") echo "Wpisz nazwę grupy którą chcesz dodać i naciśnij ENTER : " ; read group ; sudo groupadd $group ; echo "grupa dodana."; break ;;
"3") delGroup ; break;;
"4") modGroup ; break ;; 
"0") break ;;
*) echo "zły wybór" ; continue ;;
esac 

done

}

#------------------------------------------------------------------------


function zadanie3
{

while [ $loop -le 10 ] ; do
clear
echo "*----------------------------------*"
echo "*            File_Menager          *"
echo "*----------------------------------*"
echo "*                                  *"
echo "*  1) Aktualna Pozycja             *"
echo "*  2) Przejdź wyżej                *"
echo "*  3) Lista Plików                 *"
echo "*  4) Drzewko Plików               *"
echo "*  5) Szukaj Pliku                 *"
echo "*  6) Zmiana Uprawniń              *"
echo "*  7) Zmiana Właściciela           *"
echo "*  8) Zmiana Nazwy                 *"
echo "*  9) Stwórz plik                  *"
echo "* 10) Poruszanie się po katalogach *"
echo "*  0) Powrót                       *"
echo "*                                  *"  
echo "*----------------------------------*"
echo "Wpisz numer zadania i naciśnij ENTER. . . " ; read z3Wybor 
clear
case $z3Wybor in
"1") pwd ; read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . . " ; echo  ;;
"2") cd .. ;;
"3") ls -a ; read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . . " ; echo  ;;
"4") pstree ; read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . . " ; echo   ;;
"5") echo "Wpisz nazwę pliku którego chcesz znaleźć i naciśnij enter" ; read toFind  ; locate $toFind ; read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . . "  ;; # find i locate  
"6") modRights ; break ;;
"7") changeOwner ; break ;;
"8") changeName ; break ;;
"9") newFile ; break ;;
"10") moving ; break ;;
"0") break ;;
*) echo "Zły wybór . . ." ;;
esac

done
}

#------------------------------------------------------------------------


function zadanie4
{
while [ $loop -le 10 ] ; do
clear
echo "*-------------------------*"
echo "*      Info o Systemie    *"
echo "*-------------------------*"
echo "*                         *"
echo "*    1) Info_CPU          *"
echo "*    2) Architektura      *"
echo "*    3) Wersja Kernela    *"
echo "*    4) Urządzenia PCI    *"
echo "*    5) Urządzenia USB    *"
echo "*    0) Powrót            *"
echo "*                         *"
echo "*-------------------------*"

read -rsn1 -p "Wybierz numer zadania . . ." z4Wybor; echo
case $z4Wybor in
"1") cat /proc/cpuinfo ; read -rsn1 -p "Naciśnij dowolny klawisz aby kontynuować . . ."; echo ; break ;;
"2") arch ; read -rsn1 -p "Naciśnij dowolny klawisz aby kontynuować . . ."; echo  ; break ;;
"3") uname -r ; read -rsn1 -p "Naciśnij dowolny klawisz aby kontynuować . . ."; echo ; break ;;
"4") lspci -tv ; read -rsn1 -p "Naciśnij dowolny klawisz aby kontynuować . . ."; echo ; break ;;
"5") lsusb -tv ; read -rsn1 -p "Naciśnij dowolny klawisz aby kontynuować . . ."; echo ; break ;;
"0") break ;;
*) echo "Zły wybór . . ." ;;
esac 

done
}

#------------------------------------------------------------------------
#funkcje pomocnicze


function modUsers 
{
while [ $loop -le 8 ] ; do

clear
sn= cut -d : -f 1 /etc/passwd ; echo $sn ; 
echo "Wpisz nazwę użytkownika i naciśnij ENTER : " ; read user


echo "*-------------------------------*"
echo "*                               *"
echo "*    1) Zmiana Hasła            *"
echo "*    2) Dodanie do grupy        *"
echo "*    3) Zmiana Nazwy            *"
echo "*    0) Powrót                  *"
echo "*                               *"
echo "*-------------------------------*"
read -rsn1 -p "Wybierz numer zadania" Wybor ; echo 
case $Wybor in
"1") echo "Podaj nowe hasło : " ; read newPassword ; sudo usermod $user -p $newPassword ; break  ;;
"2")  echo "Podaj nazwę grupy : " ; read toGroup ; sudo usermod $user -G $toGroup ; break  ;;
"3") echo "Podaj nową nazwe : " ; read newName ; sudo usermod $user -l $newName  ; break ;;
"0") break ;;
*) echo "Zły wybór" ; sleep 2;;
esac

done
}

function delUser
{
sn= cut -d : -f 1 /etc/passwd ; echo $sn ; 
echo "Wpisz nazwę użytkownika którego chcesz usunąć i naciśnij ENTER : " ; read user 
isPresent= grep -c $user /etc/passwd
if [ $isPresent=1 ]
then sudo userdel $user
else echo $isPresent  ;echo "Brak użytkownika."
fi
read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . ." x; echo

}
#------------------------------------------------------------------------------------
function delGroup
{
sn= cut -d : -f 1 /etc/group  ; echo $sn
echo "Wpisz nazwę grupy którą chcesz usunąć i naciśnij ENTER : " ; read group 
isPresent= grep -c $group /etc/group
if [ $isPresent=1 ]
then sudo groupdel $group ; echo "usunięte"
else echo $isPresent  ;echo "Brak grupy."
fi

read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . ." ; echo

}

function modGroup
{
while [ $loop -le 10 ] ; do
echo "*-------------------------------*"
echo "*                               *"
echo "*    1) Lista                   *"
echo "*    2) Zmiana Nazwy            *"
echo "*    3) Zmiana Uprawnień        *"
echo "*    4) Zmiana Hasła            *"
echo "*    0) Powrót                  *"
echo "*                               *"
echo "*-------------------------------*"

read -rsn1 -p "Wybierz numer zadania . . . " Wybor ; echo
case $Wybor in 
"1") sn= cut -d : -f 1 /etc/group ; echo $sn ; continue  ;; 
"2") echo "Wpisz nazwę grupy którą chcesz zmienić i naciśnij enter " ; read oldName ; clear ; echo "Wpisz nową nazwę i naciśnij enter " ; read newName ; sudo groupmod -n $newName $oldName ;  break ;;
"3")   break ;;
"4")   break ;;
"0")   break ;;
*)   ;;


esac
done

}

#------------------------------------------------------------------------------------
function modRights 
{
clear
while [ $loop -le 10 ] ; do
echo "Wpisz nazwę pliku któremu chcesz zmienić prawa i nacisnij ENTER :" ; read toMod
echo "Podaj liczbę uprawnień i naciśnij ENTER :" ; read rights
isPresent= find $toMod
if [ $toMod=$isPresent ] ;
then chmod $rights $toMod ; break
else echo "Brak pliku albo błędne prawa . . . " 
fi
done
}
function changeOwner
{
echo "Wpisz nazwę nowego właściciela i naciśnij ENTER : " ; read newOwner ;
echo "Podaj nazwę pliku i naciśnij ENTER : " ; read toChange ;
sudo chown $newOwner $toChange 	
read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . ." ; echo
}
function changeName
{
echo "Jesteś w : " ; pwd
echo "dostępne pliki to" ; ls
echo "wpisz nazwę pliku do zmiany i naciśnij ENTER : " ; read oldName
echo "Wpisz nową nazwę pliku i naciśnij ENTER : " ; read newName
sudo mv $oldName $newName 
echo "aktualna lista plików : " ; ls
read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . ." ; echo

}
function newFile
{
echo "Wpisz nazwę pliku który chcesz stworzyć i naciśnij ENTER : " ; read toTouch ; touch $toTouch
}

function moving
{
while [ $loop -le 10 ] ; do
clear
echo "jesteś w : " ; pwd 
echo "------------------------------------------------------------------"
echo "Znajdujące się tu katalogi : "
ls -F|grep /
echo "------------------------------------------------------------------"
echo "Jeśli chcesz wejść wyżej wpisz .. i naciśnij ENTER :  "
echo "Jeśli chcesz wejść do katalogu wpisz jego nazwę i naciśnij ENTER : "
echo "Jeśli chcesz wyjść wpisz exit i naciśnij ENTER : "
read choice ;

if [ $choice = "exit" ] ; 
then break ;
else cd $choice ;
fi

done
}
#------------------------------------------------------------------------


function wyjscie
{
clear
echo "Good Bye" ; sleep 1
clear
exit
}


#--------------------








# główne Wykonywanie
while [ $loop -le 8 ] ; 
do
menu
done
