using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryp
{
    public class Davici
    {
        public string TextEncrypt(string clave, string text){
            
            if(string.IsNullOrWhiteSpace(clave) || string.IsNullOrWhiteSpace(text) )
                return "error";

            List<char> ABCedario = ("ABCDEFGHIJKLMNÑOPQRSTUVWXYZ").ToCharArray().ToList();
            char[] Col = clave.ToUpper().ToCharArray(); //clave
            char[] Row  = text.ToUpper().ToCharArray(); //texto
            
            string Encriptation = "";
            int j = 0;

            for (int i = 0; i < Row.Length; i++)
            {

                int ROW = ABCedario.IndexOf(Row[i]); //texto
                int COL = ABCedario.IndexOf(Col[j]); //clave
                    
                if(ROW < 0 || COL < 0){
                    Encriptation += Row[i];
                    continue;
                }

                int NewLetter =  ROW + COL;

                if(NewLetter > 26) 
                    NewLetter = NewLetter - 27;
                

                Encriptation += ABCedario.ElementAt(NewLetter);

                j++;
                if(j > Col.Length-1) j = 0;
            }
            
            //iwvevogta uavlm qmmoñln cmfet. kj xb woy. <-resultado esperado
            //IWVEVOGTA UAVLM QMMOÑLN CMFET. KJ XB WOY.
            return Encriptation;
        }

        public string TextDecrypt(string clave, string text)
        {
            if(string.IsNullOrWhiteSpace(clave) || string.IsNullOrWhiteSpace(text) )
                return "error";
                
            List<char> ABCedario = ("ABCDEFGHIJKLMNÑOPQRSTUVWXYZ").ToCharArray().ToList();
            char[] Col = clave.ToUpper().ToCharArray(); //clave
            char[] Row  = text.ToUpper().ToCharArray(); //texto

            string Encriptation = "";
            int j = 0;

            for (int i = 0; i < Row.Length; i++)
            {

                int ROW = ABCedario.IndexOf(Row[i]); //texto
                int COL = ABCedario.IndexOf(Col[j]); //clave

                if(ROW < 0 || COL < 0){
                    Encriptation += Row[i];
                    continue;
                }

                int NewLetter =  ROW - COL;

                if(NewLetter < 0) 
                    NewLetter = 27 + NewLetter;
                

                Encriptation += ABCedario.ElementAt(NewLetter);

                j++;
                if(j > Col.Length-1) j = 0;
            }
            
            //iwvevogta uavlm qmmoñln cmfet. kj xb woy. <-resultado esperado
            //IWVEVOGTA UAVLM QMMOÑLN CMFET. KJ XB WOY.
            return Encriptation;
        }

    }
}
