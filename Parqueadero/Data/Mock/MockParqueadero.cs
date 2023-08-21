using Parqueadero.Data.Dto;

namespace Parqueadero.Data.Mock
{
    public class MockParqueaderoDto: IMockParqueaderoDto
    {
        public List<ParqueaderoDto> getMockParqueadero()
        {
             List <ParqueaderoDto> listaParqueaderoDtos = new List<ParqueaderoDto>
                {
                 new ParqueaderoDto
                    {
                        Nombre = "ParqueAuto",
                        Descripcion = "ParqueaderoDto seguro en el centro de la ciudad",
                        Direccion = "Calle 123, Centro, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "RutaGaraje",
                        Descripcion = "Amplio estacionamiento para vehículos de todos los tamaños",
                        Direccion = "Avenida Principal, Barrio Norte, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "AndénParking",
                        Descripcion = "Estacionamiento con múltiples niveles y tecnología de punta",
                        Direccion = "Carrera 456, Zona Comercial, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "CarrilCocheras",
                        Descripcion = "Espacios exclusivos para vehículos de lujo y deportivos",
                        Direccion = "Calle 789, Barrio Exclusivo, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "SeguroEstaciona",
                        Descripcion = "Tu seguridad es nuestra prioridad, vigilancia las 24 horas",
                        Direccion = "Carrera 1010, Urbanización Segura, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "PlazaAutos",
                        Descripcion = "Un lugar donde cada auto tiene su propio espacio",
                        Direccion = "Avenida Principal, Zona Industrial, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "ValleAutomotor",
                        Descripcion = "Amplio valle de estacionamiento para comodidad de todos",
                        Direccion = "Calle 1212, Barrio Tranquilo, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "EjeEstaciona",
                        Descripcion = "En el corazón de la ciudad, cerca de todo",
                        Direccion = "Carrera 1414, Centro Histórico, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "GarajeColonial",
                        Descripcion = "Ambiente colonial para estacionar con estilo",
                        Direccion = "Calle 1616, Zona Antigua, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "CieloEstaciona",
                        Descripcion = "Aparca en las alturas y disfruta de vistas panorámicas",
                        Direccion = "Carrera 1818, Colina Vista, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "EstrellaParking",
                        Descripcion = "Encuentra tu espacio bajo el cielo estrellado",
                        Direccion = "Calle 2020, Nocturno Plaza, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "PaisajeGaraje",
                        Descripcion = "Estacionamiento rodeado de hermosos paisajes naturales",
                        Direccion = "Avenida 2222, Parque Natural, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "TropicalPark",
                        Descripcion = "Estaciona tu vehículo en un oasis tropical",
                        Direccion = "Calle 2424, Zona Tropical, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "AventuraCocheras",
                        Descripcion = "Una experiencia emocionante desde el momento que llegas",
                        Direccion = "Carrera 2626, Parque Aventura, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "SolGaraje",
                        Descripcion = "Estaciona bajo el brillante sol colombiano",
                        Direccion = "Avenida 2828, Solar Resplandor, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "OasisAutomotor",
                        Descripcion = "Refugio para tu vehículo en medio del bullicio urbano",
                        Direccion = "Calle 3030, Oasis Urbano, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "MagicoEstaciona",
                        Descripcion = "Un lugar donde la magia de estacionar cobra vida",
                        Direccion = "Carrera 3232, Zona Encantada, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "GaleriaParking",
                        Descripcion = "Disfruta de arte mientras encuentras tu espacio",
                        Direccion = "Avenida 3434, Galería Arte, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "FiestaCocheras",
                        Descripcion = "El estacionamiento donde cada día es una fiesta",
                        Direccion = "Calle 3636, Zona Festiva, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "CascadaGaraje",
                        Descripcion = "Estacionamiento cerca de una hermosa cascada natural",
                        Direccion = "Carrera 3838, Cascada Serena, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "BravoParking",
                        Descripcion = "Aplausos para tu elección de estacionamiento",
                        Direccion = "Avenida 4040, Bravo Plaza, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "ArcoirisAutomotor",
                        Descripcion = "La diversidad de opciones en un solo lugar",
                        Direccion = "Calle 4242, Arcoiris Avenida, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "SaborEstaciona",
                        Descripcion = "La experiencia de estacionar con toque gastronómico",
                        Direccion = "Carrera 4444, Sabor Delicias, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "AmigoGaraje",
                        Descripcion = "Un amigo para tu vehículo en cada momento",
                        Direccion = "Avenida 4646, Amigo Urbanización, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "MontañaParking",
                        Descripcion = "Estacionamiento con vista a majestuosas montañas",
                        Direccion = "Calle 4848, Montaña Vista, Ciudad"
                    },
                new ParqueaderoDto
                    {
                        Nombre = "AireAutomotor",
                        Descripcion = "Amplio espacio y aire fresco para tu vehículo",
                        Direccion = "Carrera 5050, Aire Libre, Ciudad"

                    }

               
            };
            return listaParqueaderoDtos;
        }

        public List<string> getComentarios()
        {

            List<string> Comentarios = new List<string>
                {
                    "¡Excelente servicio! Siempre encuentro un espacio disponible.",
                    "El sistema de pagos es muy conveniente y rápido.",
                    "Me encanta la app móvil para reservar mi lugar con anticipación.",
                    "El personal es amable y siempre está dispuesto a ayudar.",
                    "El parqueadero podría mejorar en la señalización de las salidas.",
                    "A veces hay demoras en el proceso de pago en horas pico.",
                    "La tarifa por hora es razonable en comparación con otros lugares.",
                    "Sería genial tener una opción de lavado de autos mientras estaciono.",
                    "La seguridad del parqueadero me hace sentir tranquilo al dejar mi vehículo.",
                    "He experimentado problemas al escanear el código QR en el ticket de estacionamiento.",
                    "Siempre que vengo, el personal es muy atento y servicial.",
                    "Me gustaría que hubiera más iluminación en el área de estacionamiento.",
                    "La limpieza del parqueadero podría mejorar, pero en general está bien.",
                    "La reserva de espacios en línea ha hecho mi vida mucho más fácil.",
                    "Es genial ver opciones de carga para vehículos eléctricos en el parqueadero.",
                    "El acceso para personas con discapacidad está bien implementado.",
                    "Las tarifas nocturnas podrían ser un poco más económicas.",
                    "¡Increíble! Olvidé una pertenencia en mi auto y el personal la guardó hasta que regresé.",
                    "El proceso de ingreso y salida es fluido, no he tenido problemas hasta ahora.",
                    "El tamaño de los espacios de estacionamiento es adecuado para vehículos grandes.",
                    "Me gustaría tener más opciones de comida rápida cerca del parqueadero.",
                    "La opción de suscripción mensual ha sido una gran ventaja para mí.",
                    "El parqueadero podría ofrecer más servicios adicionales, como inflado de neumáticos.",
                    "He tenido problemas con la app en algunas ocasiones, se desconecta a veces.",
                    "¡Definitivamente recomendaría este parqueadero a amigos y familiares!"
                };

            return Comentarios;

        }
    }
}
