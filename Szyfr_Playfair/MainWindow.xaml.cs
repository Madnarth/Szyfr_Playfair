using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szyfr_Playfair
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void szyfruj(object sender, RoutedEventArgs e)
        {
            int licznik = 0;
            int i = 0;
            int j = 0;
            bool warunek;
            string temp_klucz ="";
            string temp_tekst ="";
            StringBuilder sb = new StringBuilder(TxtBoxKlucz.Text);
            int []wspolrzedne = new int [2];
            char temp ='a';
            //Tworzenie klucza na podstawie słowa kluczowego
            for (i = 0; i < TxtBoxKlucz.Text.Length; i++) //Usuwanie powtarzających się znaków
            {
                warunek = true;
                for (j = 0; j < temp_klucz.Length; j++)
                {
                    if (TxtBoxKlucz.Text[i] == temp_klucz[j])
                    {
                        warunek = false;
                        break;
                    }
                }
                if (warunek)
                {
                    temp_klucz += TxtBoxKlucz.Text[i];
                }
            }

            for (i = 65; i < 91; i++)//Dodawanie reszty alfabetu do słowa klucza
            {
                warunek = true;
                for (j = 0; j < temp_klucz.Length; j++)
                {
                    if (temp_klucz[j] == i)
                    {
                        warunek = false;
                        break;
                    }
                }
                if (warunek)
                {
                    temp_klucz += i;
                }
            }
            TxtBoxKlucz.Text = temp_klucz;

            warunek = false;
            for (i = 0; i < 25; i++)
            {
                if (TxtBoxKlucz.Text[i] =='J')
            {
                warunek = true;
            }
            if (warunek)
            {
                    sb[i] = TxtBoxKlucz.Text[i + 1];
                    TxtBoxKlucz.Text = sb.ToString();
            }
        }

        //Przygotowanie tekstu jawnego do obróbki
        temp_tekst+= TxtBoxNieszyf.Text[0];
    for(i=1;i< TxtBoxNieszyf.Text.Length;i++)
    {
        if(temp== TxtBoxNieszyf.Text[i])
            temp_tekst+='X';
        if(TxtBoxNieszyf.Text[i]=='J')
            temp_tekst+='I';
        else
            temp_tekst+= TxtBoxNieszyf.Text[i];
        temp= TxtBoxNieszyf.Text[i];
    }
    if(TxtBoxNieszyf.Text.Length%2==1)
        TxtBoxNieszyf.Text +='X';
        TxtBoxNieszyf.Text = temp_tekst;
    
    
    //Proces szyfrowania
    for(i=0;i< TxtBoxNieszyf.Text.Length;i+=2)
    {
        //Przeszukiwanie klucza
        for(j=0;j<25;j++)
        {
            if(TxtBoxKlucz.Text[j]== TxtBoxNieszyf.Text[i])
                wspolrzedne[0]=j;    
            if(TxtBoxKlucz.Text[j]== TxtBoxNieszyf.Text[i + 1])
                wspolrzedne[1]=j;
        }
        
        //Szyfrowanie
        if((wspolrzedne[0]%5)==(wspolrzedne[1]%5))//Pionowo
        {
                    sb[i]= TxtBoxKlucz.Text[(wspolrzedne[0] + 5) % 25];
                    TxtBoxKlucz.Text = sb.ToString();
                    sb[i + 1]= TxtBoxKlucz.Text[(wspolrzedne[1] + 5) % 25];
                    TxtBoxKlucz.Text = sb.ToString();
        }
        else if((wspolrzedne[0]/5)==(wspolrzedne[1]/5))//Poziomo
        {
                    sb[i]= TxtBoxKlucz.Text[(wspolrzedne[0] / 5) * 5 + ((wspolrzedne[0] % 5 + 1) % 5)];
                    TxtBoxKlucz.Text = sb.ToString();
                    sb[i + 1]= TxtBoxKlucz.Text[(wspolrzedne[1] / 5) * 5 + ((wspolrzedne[1] % 5 + 1) % 5)];
                    TxtBoxKlucz.Text = sb.ToString();
                }
        else//Na ukos
        {
                    sb[i]= TxtBoxKlucz.Text[(wspolrzedne[0] / 5) * 5 + (wspolrzedne[1] % 5)];
                    TxtBoxKlucz.Text = sb.ToString();
                    sb[i + 1]= TxtBoxKlucz.Text[(wspolrzedne[1] / 5) * 5 + (wspolrzedne[0] % 5)];
                    TxtBoxKlucz.Text = sb.ToString();
                }
    }
        }

        private void sprawdzaj_klucz(object sender, TextChangedEventArgs e)
        {

        }

        private void deszyfruj(object sender, RoutedEventArgs e)
        {

        }
    }
}
