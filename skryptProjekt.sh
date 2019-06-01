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
echo "*        1) Gracz       *"
echo "*        0) Exit        *"

read -rsn1 -p "Podaj numer zadania . . . " wyborMenu ; echo 
case $wyborMenu in 
"1") Gracz  ;;
"0") clear ; echo "Bye Bye" ; sleep 1 ; clear ; exit ;;
*) ;;
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
cut -d , -f 2 3 1 $nazwaPliku.txt ; sleep 3


}
#------------------------------#
while [ $loop -le 1 ] ; do
Menu 
done
