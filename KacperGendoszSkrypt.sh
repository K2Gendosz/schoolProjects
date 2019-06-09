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
"0") clear ; echo "Bye Bye" ; sleep 1 ; clear ; exit ;;
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
*) echo "Zły wybór . . ." ; sleep 1 ;;
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
echo "------------------------------------------------------------------"
echo "Podaj nazwę katalogu którego chcesz przeszukać i naciśnij enter : " ; read dirToSearch ;
echo "------------------------------------------------------------------"
cd $Home ;
pathToDir=`locate -b  $dirToSearch`
size=${#pathToDir}
if [ $size -gt 0 ];
then
{
clear
cd $pathToDir 
echo "------------------------------------------------------------------"
echo "Wpisz nazwę pliku którego chcesz poszukać : " ; read fileToSearch ;
echo "------------------------------------------------------------------"

path=`find -name $fileToSearch*`
echo $path ;
clear
if [ -f "$path" ];
then cat $fileToSearch.txt ; echo " " ; read -rsn1 -p " Wciśnij dowolny klawisz aby kontynuować . . . " ; echo ; break
else echo "W katalogu $dirToSearch nie ma pliku o nazwie $fileToSearch." ;
fi
read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . . " ; echo
break
}
else
{
echo "Brak katalogu $dirToSearch "
read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . . " ; echo
break
}
fi
done
}
#------------------------------#
function ToCopy
{
while [ $loop -le 1 ] ; do 

clear
echo "------------------------------------------------------------------"
echo "Podaj nazwę katalogu : " ; read dirToCopy 
echo "------------------------------------------------------------------"
cd $Home 
pathToCopy=`locate -b  $dirToCopy`
clear
size=${#pathToCopy}
if [ $size -gt 0 ];
then
{
clear 
echo "------------------------------------------------------------------"
echo "Wprowadź nazwe rozszerzenia : " ; read ex
cd $pathToCopy
length=`find $pathToCopy -name "*$ex"| wc -l  | cut -d " " -f 1`
clear
if [ $length -gt 0 ]; 
then
{
data=`date +%F`
mkdir -p $data
cp *.$ex $data
echo "pliki skopiowano"
}
else
{
clear
echo "Brak plików z rozszerzeniem .$ex "
}
fi
read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . . " ; echo
break
}
else
{
clear
echo "Brak katalogu $dirToCopy "
read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . . " ; echo
break
}

fi
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
ip link show | cut -d " " -f 1-3 | cut -d $'\n' -f 1,3,5,7,9,11,13 | cut -d : -f 1-2
echo "Wpisz nazwę interfejsu i naciśnij ENTER : " ; read card
clear
echo "Podaj IP i naciśnij ENTER : " ; read ipNumb
echo "Podaj Maskę i naciśnij ENTER :  " ; read mask
echo "Podaj Bramę Domyślną i naciśnij ENTER : " ; read gate
echo "Podaj adres DNS i naciśnij ENTER : " ; read dns
ifconfig $card $ipNumb netmask $mask 
route add default gw $gate $card 
sudo chmod 777 /etc/resolv.conf
echo "nameserver $dns" >> /etc/resolv.conf
read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . . " ; echo
}


function Auto
{
clear
echo "Dostępne interfejsy sieciowe :" ; 
ip link show | cut -d " " -f 1-3 | cut -d $'\n' -f 1,3,5,7,9,11,13 | cut -d : -f 1-2
echo "Wpisz nazwę interfejsu i naciśnij ENTER : " ; read card
clear
ifconfig $card 192.168.1.1/254 netmask 256.256.256.1/254
route add default gw 192.168.1.1/254 $card
sudo chmod 777 /etc/resolv.conf
echo "nameserver 127.0.0.53" >> /etc/resolv.conf
read -rsn1 -p "Wciśnij dowolny klawisz aby kontynuować . . . " ; echo
}
#------------------------------#
while [ $loop -le 1 ] ; do
Menu 
done
