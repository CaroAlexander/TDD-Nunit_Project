using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    public class ServicioClave{
        public bool ValidarClave(string clave){
            if (ValidarMayuscula(clave) && ValidarMinuscula(clave) &&  ValidarLongitudClave(clave) && ValidarCaracterEspecial(clave) && ValidarCaracterEspecial(clave)) return true;
            return false;
        }
        public bool ValidarMayuscula(string clave){
            foreach (char ch in clave){
                if (Char.IsUpper(ch)){
                    return true;
                }
            }
            return false;
        }
        public bool ValidarMinuscula(string clave){
            foreach (char ch in clave){
                if (Char.IsLower(ch)){
                    return true;
                }
            }
            return false;
        }
        public bool ValidarLongitudClave(string clave) {
            if (clave.Length>=6 && clave.Length<=12){
                    return true;
            }
            return false;
        }
        public bool ValidarCaracterEspecial(string clave) {
            var regexCaracterEspecial = new Regex(@"[~'!@#$%^&*()+=|\\{}´:;.,<>/?[\]""_-]");
            if (!regexCaracterEspecial.IsMatch(clave)){
                    return false;
            }
            return true;
        }
        public bool ValidarDigito(string clave) {
            foreach (var ch in clave) {
                if (Char.IsDigit(ch)){
                    return true;
                }
            }
            return false;
        }
    }
}   