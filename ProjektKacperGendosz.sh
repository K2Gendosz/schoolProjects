#!/bin/bash

#-------------------------------#
loop=0

#-------------------------------#


function Menu
{
clear

echo "*-----------------------*"
echo "*         MENU          *"
echo "*-----------------------*"
echo "*                       *"
echo "* 1) Szukanie Katalogu  *"
echo "* 2) Gracz              *"
echo "* 3) Kopiowanie plików  *"
echo "* 4) Karty sieciowe     *"
echo "*                       *"
echo "* 0) Exit               *"
echo "*                       *"
echo "*-----------------------*"

read -rsn1 -p "Podaj numer zadania . . . " wyborMenu ; echo 
case $wyborMenu in 
"1") DirSearch ;;
"2") Gracz  ;;
"3") ToCopy ;;
"4") NetCard ;;
"0") clear ; echo "*** Good Bye ***" ; sleep 1 ; clear ; exit ;;
*) echo "" ; echo "Błędny wybór . . ." ; sleep 1 ;;
esac


}
 

#------------------------------#
function Gracz
{
echo "Podaj nazwę pliku i naciśnij ENTER : " ; read nazwaPliku 
touch $nazwaPliku.txt
while [ $loop -le 1 ] ; do
clear
echo "Podaj numer gracza : " ; read numerGracza
echo "Podaj imię gracza : " ; read imieGracza 
echo "Podaj nazwisko gracza : " ; read nazwiskoGracza
echo "Podaj nazwę klubu : " ; read nazwaKlubu
echo "Podaj ilość punktów gracza : " ; read punkty
container="$numerGracza,$imieGracza,$nazwiskoGracza,$nazwaKlubu,$punkty"
read -rsn1 -p "Dodać kolejnego gracza Wciśnij t/n :" wyborGracz ; echo 
case $wyborGracz in 
"t")  echo $container >> $nazwaPliku.txt ; continue ;;
"n")  echo $container >> $nazwaPliku.txt ; break ;;
*) echo " " ; echo  "Zły wybór wpisz zawodnika jeszcze raz." ; sleep 2 ;;
esac
done
echo "Gracze : "
awk -F"," '{ print $2 " " $3 " " $1 }' $nazwaPliku.txt
read -rsn1 -p "Wciśnij dowolny przycisk aby kontynuować . . . " ; echo 
}
#-----------------------------#
function DirSearch
{

while [ $loop -le 1 ] ; do 
clear
searchDir
case $ret in 
"1") searchFile ; break ;;
"0") read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . ." ; break ;;
*) echo "upsi coś poszło nie tak." ; sleep 3 ; continue  ;;
esac
done
}
#------------------------------#
function ToCopy
{
while [ $loop -le 1 ] ; do 
clear
searchDir
case $ret in
"1") copyMod ; break ;;
"0") read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . ." ; break ;;
*) echo "upsi coś poszło nie tak." ; sleep 3 ; continue ;;
esac
done
}
#------------------------------#
function NetCard
{
clear
echo "*------------------------*"
echo "*   NetworcCardManager   *"
echo "*------------------------*"
echo "*                        *"
echo "* 1) Ustawienia Ręczne   *"
echo "* 2) Ustawienia Auto     *"
echo "*                        *"
echo "*------------------------*"
read -rsn1 -p "Wybierz tryb . . . " cardChoice ; echo
case $cardChoice in
"1") Manual ;;
"2") Auto ;;
*) echo "" ; echo "Błędny wybór . . ." ; sleep 1 ;;
esac
}
#------------------------------#
function Manual
{
clear
echo "Dostępne interfejsy sieciowe :" ; 
cd /
ls sys/class/net/
echo "Wpisz nazwę interfejsu i naciśnij ENTER : " ; read card
clear
echo "Podaj IP i naciśnij ENTER : " ; read ipNumb
echo "Podaj Maskę i naciśnij ENTER :  " ; read mask
echo "Podaj Bramę Domyślną i naciśnij ENTER : " ; read gate
echo "Podaj adres DNS i naciśnij ENTER : " ; read dns
sudo ifconfig $card $ipNumb netmask $mask
sudo route add default gw $gate
echo nameserver $dns >> /etc/resolv.conf


read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . . " ; echo
}


function Auto
{
clear
echo "Dostępne interfejsy sieciowe :" ; 
cd /
ls sys/class/net/
echo "Wpisz nazwę interfejsu i naciśnij ENTER : " ; read card
sudo dhclient $card
echo " "
read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . . " ; echo

}
#------------------------------#
function searchDir
{
echo "------------------------------------------------------------------"
echo "Podaj nazwę katalogu którego chcesz przeszukać i naciśnij enter : " ; read dirToSearch ;
echo "------------------------------------------------------------------"
cd $HOME
dirPath=`find -name $dirToSearch`
length=`find -name $dirToSearch | wc -l`
if [ $length = 0 ]; then
{ 
echo "Brak katalogu $dirToSearch"
ret=0
} 
elif [ $length = 1 ]; then
{ 
cd $dirPath
pwd ; sleep 0.5
ret=1
}
else
{ 
echo "Znaleziono kilka folderów o nazwie $dirToSearch : "
find -name $dirToSearch
echo "Wpisz ścieżkę do którego folderu chcesz się dostać i naciśnij ENTER :"
read toCD
cd $toCD
pwd ; sleep 0.5
ret=1
}
fi
}
#------------------------------#
function searchFile
{
clear 
echo "Dostępne pliki :"
echo ""
find -maxdepth 1 -type f | cut -d "/" -f 2
echo ""
sleep 0.7
echo "------------------------------------------------------------------"
echo "Podaj nazwę pliku i naciśnij ENTER :" ; read fileToS
echo "------------------------------------------------------------------"
cat < $fileToS
echo " "
echo " "
read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . ." ; echo
}
#------------------------------#
function copyMod
{
echo "Podaj nazwę rozszerzenia : " ; read ex
length=`find -maxdepth 1 -name "*.$ex" | wc -l`
if [ $length = 0 ]; then
{
echo "Brak plików z rozszerzeniem $ex"
}
else
{
dzisiaj=`date +%M.%S.%d_%m_%y`
mkdir $dzisiaj
cp `find -maxdepth 1 -name "*.$ex" | cut -d "/" -f 2 ` $dzisiaj
echo "Pliki zostały skopiowane do katalogu $dzisiaj. "
read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . ." ; echo
}
fi
}
#------------------------------#
while [ $loop -le 1 ] ; do
Menu 
done
