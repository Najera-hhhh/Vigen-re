using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryp
{
    public class Davici
    {
        int _maxletters = 27;
        public string TextEncrypt(string clave, string text, string idioma)
        {

            if (string.IsNullOrWhiteSpace(clave) || string.IsNullOrWhiteSpace(text))
                return "error";
            List<char> ABCedario;

            if (idioma == "Español")
                ABCedario = ("ABCDEFGHIJKLMNÑOPQRSTUVWXYZ").ToCharArray().ToList();
            else{
                ABCedario = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ").ToCharArray().ToList();
                _maxletters = 26;
            }
                

            char[] Col = clave.ToUpper().ToCharArray(); //clave
            char[] Row = text.ToUpper().ToCharArray(); //texto

            string Encriptation = "";
            int j = 0;

            for (int i = 0; i < Row.Length; i++)
            {

                int ROW = ABCedario.IndexOf(Row[i]); //texto
                int COL = ABCedario.IndexOf(Col[j]); //clave

                if (ROW < 0 || COL < 0)
                {
                    Encriptation += Row[i];
                    continue;
                }

                int NewLetter = ROW + COL;

                if (NewLetter > (_maxletters-1))
                    NewLetter = NewLetter - _maxletters;


                Encriptation += ABCedario.ElementAt(NewLetter);

                j++;
                if (j > Col.Length - 1) j = 0;
            }

            //iwvevogta uavlm qmmoñln cmfet. kj xb woy. <-resultado esperado
            //IWVEVOGTA UAVLM QMMOÑLN CMFET. KJ XB WOY.
            return Encriptation;
        }

        public string TextDecrypt(string clave, string text, string idioma)
        {
            if (string.IsNullOrWhiteSpace(clave) || string.IsNullOrWhiteSpace(text))
                return "error";

            List<char> ABCedario;
            if (idioma == "Español")
                ABCedario = ("ABCDEFGHIJKLMNÑOPQRSTUVWXYZ").ToCharArray().ToList();
            else
                ABCedario = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ").ToCharArray().ToList();
            char[] Col = clave.ToUpper().ToCharArray(); //clave
            char[] Row = text.ToUpper().ToCharArray(); //texto

            string Encriptation = "";
            int j = 0;

            for (int i = 0; i < Row.Length; i++)
            {

                int ROW = ABCedario.IndexOf(Row[i]); //texto
                int COL = ABCedario.IndexOf(Col[j]); //clave

                if (ROW < 0 || COL < 0)
                {
                    Encriptation += Row[i];
                    continue;
                }

                int NewLetter = ROW - COL;

                if (NewLetter < 0)
                    NewLetter = _maxletters + NewLetter;


                Encriptation += ABCedario.ElementAt(NewLetter);

                j++;
                if (j > Col.Length - 1) j = 0;
            }

            //iwvevogta uavlm qmmoñln cmfet. kj xb woy. <-resultado esperado
            //IWVEVOGTA UAVLM QMMOÑLN CMFET. KJ XB WOY.
            return Encriptation;
        }

    }
}
