using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Paquetes.Domain.Entities;
using Microservicio_Paquetes.Domain.DTO;
using Microservicio_Paquetes.Domain.Commands;
using Microservicio_Paquetes.Domain.Queries;
using Microservicio_Paquetes.Domain.Responses;

namespace Microservicio_Paquetes.Application.Services
{
    public interface IPaqueteService
    {
        public Response PostPaquete(PaqueteDto paquete);
        public object GetPaqueteId(int id);

        public object GetPaquetes();

        public object GetPaquetes(string idDestino);
    }

    public class PaqueteService: IPaqueteService
    {
        private readonly ICommands _commands;
        private readonly IQueries _queries;

        public PaqueteService (ICommands commands, IQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        public object GetPaquetes(string idDestino)
        {
            var paqueteDestinos = _queries.Traer<PaqueteDestino>();

            var paquetesARenderizar = new List<Paquete>();

            var listaOutput = new List<object>();

            // Primer filtrado, por destino

            if (idDestino.Equals(""))
            {
                foreach (Paquete x in _queries.Traer<Paquete>())
                {
                    paquetesARenderizar.Add(x);
                }
            }

            if (!idDestino.Equals(""))
            {
                foreach (PaqueteDestino x in paqueteDestinos)
                {
                    if (x.DestinoId == Int32.Parse(idDestino))
                    {
                        var paqueteAAgregar = _queries.EncontrarPor<Paquete>(x.PaqueteId);

                        if (!paquetesARenderizar.Contains(paqueteAAgregar))
                        {
                            paquetesARenderizar.Add(paqueteAAgregar);
                        }
                    }
                }
            }



            foreach (Paquete x in paquetesARenderizar)
            {
                listaOutput.Add(GetPaqueteId(x.Id));
            }

            if (listaOutput.Count == 0)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "No hay paquetes."
                };
            }

            return listaOutput;

        }
        public object GetPaquetes()
        {
            var paquetes = _queries.Traer<Paquete>();

            if (paquetes.Count == 0)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "No hay paquetes."
                };
            }

            var listaOutput = new List<PaqueteOutDto>();

            foreach (Paquete x in paquetes)
            {
                listaOutput.Add((PaqueteOutDto)GetPaqueteId(x.Id));
            }

            return listaOutput;
        }

        public Response PostPaquete(PaqueteDto paquete)
        {
            if (paquete.Nombre.Length > 50)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "El nombre de paquete supera los 50 caracteres."
                };
            }

            if (paquete.Descripcion.Length > 255)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "La descripción de paquete supera los 255 caracteres."
                };
            }

            if (paquete.Descuento >= 100 && paquete.Descuento < 0)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "El descuento tiene que estar entre 0 y 99."
                };
            }

            PaqueteEstado getPaqueteEstado = _queries.EncontrarPor<PaqueteEstado>(paquete.PaqueteEstadoId);

            if (getPaqueteEstado == null)
            {
                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "Estado de paquete con el id: " + paquete.PaqueteEstadoId + " no existe."
                };
            }

            // Falta validar fechas y bloqueo

            // Validación de 4 tupla:

            List<Destino> getDestinos = _queries.Traer<Destino>();

            List<int> destinosIds = new List<int>();

            foreach(Destino x in getDestinos)
            {
                destinosIds.Add(x.Id);
            }

            List<Hotel> getHoteles = _queries.Traer<Hotel>();

            List<int> hotelesIds = new List<int>();

            foreach (Hotel x in getHoteles)
            {
                hotelesIds.Add(x.Id);
            }

            List<HotelPension> getHotelPensiones = _queries.Traer<HotelPension>();

            List<int> hotelPensionesIds = new List<int>();

            foreach (HotelPension x in getHotelPensiones)
            {
                hotelPensionesIds.Add(x.Id);
            }

            List<int> destinosIdsNoExistentes = new List<int>();

            List<int> hotelesIdsNoExistentes = new List<int>();

            List<int> hotelPensionesIdsNoExistentes = new List<int>();

            foreach (List<int> x in paquete.ListaDestinoHotelNochesPension)
            {
                if(!destinosIds.Contains(x[0]))
                {
                    if (!destinosIdsNoExistentes.Contains(x[0]))
                    {
                        destinosIdsNoExistentes.Add(x[0]);
                    }
                }

                if (!hotelesIds.Contains(x[1]))
                {
                    if (!hotelesIdsNoExistentes.Contains(x[1]))
                    {
                        hotelesIdsNoExistentes.Add(x[0]);
                    }
                }

                if (!hotelPensionesIds.Contains(x[3]))
                {
                    if (!hotelPensionesIdsNoExistentes.Contains(x[3]))
                    {
                        hotelPensionesIdsNoExistentes.Add(x[3]);
                    }
                }
            }

            if (destinosIdsNoExistentes.Count > 0 || hotelesIdsNoExistentes.Count > 0 || hotelPensionesIdsNoExistentes.Count > 0)
            {
                string destinosNoExistentes = "";

                if (destinosIdsNoExistentes.Count == 0)
                {
                    destinosNoExistentes = "Todos los destinos están ok.";
                }
                else
                {
                    foreach (int x in destinosIdsNoExistentes)
                    {
                        destinosNoExistentes = destinosNoExistentes + " " + x;
                    }
                }

                string hotelesNoExistentes = "";

                if (hotelesIdsNoExistentes.Count == 0)
                {
                    hotelesNoExistentes = "Todos los hoteles están ok";
                }
                else
                {
                    foreach (int x in hotelesIdsNoExistentes)
                    {
                        hotelesNoExistentes = hotelesNoExistentes + " " + x;
                    }
                }

                string hotelPensionesNoExistentes = "";

                if (hotelPensionesIdsNoExistentes.Count == 0)
                {
                    hotelPensionesNoExistentes = "Todas las pensiones están ok.";
                }
                else
                {
                    foreach (int x in hotelPensionesIdsNoExistentes)
                    {
                        hotelPensionesNoExistentes = hotelPensionesNoExistentes + " " + x;
                    }
                }

                return new Response()
                {
                    Code = "BAD_REQUEST",
                    Message = "Hay hoteles/destinos/tipos de pensiones inexistenes:" +
                    " Hoteles:" + hotelesNoExistentes + 
                    ". Destinos:" + destinosNoExistentes + 
                    ". Pensiones de hotel:" + hotelPensionesNoExistentes,
                };
            }

            // Si paso esto, la 4-tupla esta validada (falta ver cantidad de noches y la cantidad de numeros en la tupla)

            int totalNochesContador = 0;

            foreach (List<int> x in paquete.ListaDestinoHotelNochesPension)
            {
                totalNochesContador = totalNochesContador + x[2];
            }

            Paquete paqueteNuevo = new Paquete()
            {
                Nombre = paquete.Nombre,
                Descripcion = paquete.Descripcion,
                FechaSalida = paquete.FechaSalida,
                FechaVuelta = paquete.FechaVuelta,
                PaqueteEstadoId = paquete.PaqueteEstadoId,
                Precio = paquete.Precio,
                Descuento = paquete.Descuento,
                TotalNoches = totalNochesContador,
                Prioridad = paquete.Prioridad,
            };

            _commands.Agregar<Paquete>(paqueteNuevo);

            // Si todos los destinos existen, agregar todas las instancias de PaqueteDestino y de paqueteHotel

            foreach (List<int> x in paquete.ListaDestinoHotelNochesPension)
            {
                PaqueteDestino paqueteDestino = new PaqueteDestino()
                {
                    DestinoId = x[0],
                    PaqueteId = paqueteNuevo.Id,
                };

                _commands.Agregar<PaqueteDestino>(paqueteDestino);
            }

            foreach (List<int> x in paquete.ListaDestinoHotelNochesPension)
            {
                PaqueteHotel paqueteHotel = new PaqueteHotel()
                {
                    HotelId = x[1],
                    PaqueteId = paqueteNuevo.Id,
                    Noches = x[2],
                    HotelPensionId = x[3],
                };

                _commands.Agregar<PaqueteHotel>(paqueteHotel);
            }

            return new Response()
            {
                Code = "OK",
                Message = "Paquete con el id: " + paqueteNuevo.Id + " y título: " + paqueteNuevo.Nombre + " creado."
            };
        }

        public object GetPaqueteId(int id)
        {
            var paquete = _queries.EncontrarPor<Paquete>(id);
            
            if (paquete == null)
            {
                return new Response()
                {
                    Code = "NOT_FOUND",
                    Message = "Paquete con el id: " + id + " no encontrado."
                };
            }

            int totalNochesContador = 0;

            List<object> listaDestinosDetalles = new List<object>();

            foreach (PaqueteHotel x in _queries.Traer<PaqueteHotel>())
            {
                if (x.PaqueteId == id)                    
                {
                    totalNochesContador = totalNochesContador + x.Noches;

                    var getHotel = _queries.EncontrarPor<Hotel>(x.HotelId);

                    var getDestino = _queries.EncontrarPor<Destino>(getHotel.DestinoId);

                    var destino = new DestinoOutDto()
                    {
                        Id = getDestino.Id,
                        Lugar = getDestino.Lugar,
                        Descripcion = getDestino.Descripcion,
                        Atractivo = getDestino.Atractivo,
                        Historia = getDestino.Historia,
                        Imagen = getDestino.Imagen
                    };

                    var hotel = new HotelOutDto()
                    {
                        Id = getHotel.Id,
                        Marca = getHotel.Marca,
                        Sucursal = getHotel.Sucursal,
                        Estrellas = getHotel.Estrellas,
                        Bloqueado = getHotel.Bloqueado,
                        DireccionId = getHotel.DireccionId,
                        DestinoId = getHotel.DestinoId,
                    };

                    var getHotelPension = _queries.EncontrarPor<HotelPension>(x.HotelPensionId);

                    var hotelPension = new HotelPensionOutDto()
                    {
                        Id = getHotelPension.Id,
                        Descripcion = getHotelPension.Descripcion,
                    };

                    var item = new{ Destino = destino, Hotel = hotel, Noches = x.Noches, HotelPension = hotelPension };

                    listaDestinosDetalles.Add(item);
                }
            }

            var output = new PaqueteOutDto()
            {
                Id = paquete.Id,
                Nombre = paquete.Nombre,
                Descripcion = paquete.Descripcion,
                FechaSalida = paquete.FechaSalida,
                FechaVuelta = paquete.FechaVuelta,
                Precio = paquete.Precio,
                Descuento = paquete.Descuento,
                PaqueteEstadoId = paquete.PaqueteEstadoId,
                TotalNoches = totalNochesContador,
                Prioridad = paquete.Prioridad,
                ListaDestinosDetalles = new List<object>(listaDestinosDetalles),
            };

            return output;
        }

        public void deletePaqueteId(int id)
        {
            _commands.BorrarPor<Paquete>(id);

            foreach(PaqueteDestino x in _queries.Traer<PaqueteDestino>())
            {
                if (x.PaqueteId == id)
                {
                    _commands.BorrarPor<PaqueteDestino>(x.Id);
                }
            }

            foreach (PaqueteHotel x in _queries.Traer<PaqueteHotel>())
            {
                if (x.PaqueteId == id)
                {
                    _commands.BorrarPor<PaqueteDestino>(x.Id);
                }
            }
        }


    }
}
