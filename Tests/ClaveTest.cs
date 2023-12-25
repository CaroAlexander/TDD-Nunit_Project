using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Services;

namespace Tests
{
    /*
     La clave debe tener:
        -Al menos 1 Mayúscula.
        -Al menos 1 Minúscula.
        -6 caractéres como mínimo.
        -12 caractéres como máximo.
        -Al menos 1 caracteres especiales (@/_-).
        -Al menos 1 digito.
    */
    class ClaveTest
    {
       ServicioClave claveServicio;

       [SetUp]
        public void SetUp(){
            claveServicio = new ServicioClave();
        }

        [TestCase("1234@", false)]
        [TestCase("12345678912ASZzx@_", false)]
        [TestCase("Clave123", false)]
        [TestCase("clave123_x", false)]
        [TestCase("Clave123_x", true)]

        public void Validar_Composicion_Clave(string clave, bool esperado)
        {
            //Given
            //ServicioClave claveServicio = new ServicioClave();
            //When
            bool actual = claveServicio.ValidarClave(clave);
            //Assert
            ClassicAssert.AreEqual(esperado, actual);
        }

        [TestCase("Axz19", true)]
        [TestCase("axz19", false)]
        [TestCase("1jsdajxfsda", false)]
        [TestCase("123adaA", true)]
        [TestCase("1A2B3C", true)]
        [TestCase("1234", false)]
        public void Clave_Debe_Tener_Almenos_1_Mayúscula(string clave, bool esperado){
            //Given
            //ServicioClave claveServicio = new ServicioClave();
            //When
            bool actual = claveServicio.ValidarMayuscula(clave);
            //Assert

            //Assert.AreEqual(actual, esperado);
            ClassicAssert.AreEqual(esperado, actual);
            //Assert.AreEqual(actual, esperado);
        }

        [TestCase("X90A123", false)]
        [TestCase("AAAAAAA", false)]
        [TestCase("u2343vAASDD", true)]
        [TestCase("aXXXXXXa", true)]
        [TestCase("A123456B", false)]
        public void Clave_Debe_Tener_Almenos_1_Minuscula(string clave, bool esperado){
            //Given
            //ServicioClave claveServicio = new ServicioClave();
            //When
            bool resultado = claveServicio.ValidarMinuscula(clave);
            //Assert
            ClassicAssert.AreEqual(esperado, resultado);
        }

        [TestCase("123", false)]
        [TestCase("123456", true)]
        [TestCase("80902", false)]
        [TestCase("xMA321", true)]
        [TestCase("Ppyx9012er81", true)]
        [TestCase("000000eeaattMAZMIN", false)]
        public void Clave_Debe_Tener_LongitudMax_Entre6y12Caracteres(string clave, bool esperado){
            //Given
            //ServicioClave claveServicio = new ServicioClave();
            //When
            bool resultado = claveServicio.ValidarLongitudClave(clave);
            //Assert
            ClassicAssert.AreEqual(esperado, resultado);
        }
        
        [TestCase("Mxz@pop12", true)]
        [TestCase("Mxqpva12", false)]
        [TestCase("as_@ss11@", true)]
        [TestCase("PPOPASD", false)]
        public void Clave_Debe_Tener_Almenos_1CaracterEspecial(string clave, bool esperado){
            //Given
            //ServicioClave claveServicio = new ServicioClave();
            //When
            bool resultado = claveServicio.ValidarCaracterEspecial(clave);
            //Assert
            ClassicAssert.AreEqual(esperado, resultado);
        }
        
        [TestCase("12313129", true)]
        [TestCase("axcaASD@_", false)]
        [TestCase("1pascqqweeAXCA@_2", true)]
        [TestCase("AAXCpioxASD21", true)]
        public void Clave_Debe_Tener_Almenos_1Digito(string clave, bool esperado){
            //Given
            //ServicioClave claveServicio = new ServicioClave();
            //When
            bool resultado = claveServicio.ValidarDigito(clave);
            //Assert
            ClassicAssert.AreEqual(esperado, resultado);
        }
    }
}