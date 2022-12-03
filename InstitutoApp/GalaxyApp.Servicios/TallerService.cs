using AutoMapper;
using GalaxyApp.Dto.Request;
using GalaxyApp.Dto.Response;
using GalaxyApp.Entidades;
using GalaxyApp.Entidades.Infos;
using GalaxyApp.Repositorios;
using Microsoft.Extensions.Logging;

namespace GalaxyApp.Servicios
{
    public class TallerService : ITallerService
    {
        private readonly ITallerRepository _repository;
        private readonly ILogger<TallerService> _logger;
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IFileUploader _fileUploader;

        public TallerService(ITallerRepository repository, 
            ILogger<TallerService> logger, IMapper mapper, 
            IInstructorRepository instructorRepository,
            IFileUploader fileUploader)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _fileUploader = fileUploader;
        }

        public async Task<BaseResponseList<TallerInfo>> Listar(RequestTallerBusqueda request)
        {
            var response = new BaseResponseList<TallerInfo>();

            try
            {
                var tupla = await _repository.Listar(request.Nombre, request.CategoriaId, request.Situacion, request.Pagina, request.Filas);

                response.Data = tupla.Lista;
                var totalPaginas = tupla.Total / request.Filas;
                if (tupla.Total % request.Filas > 0)
                    totalPaginas++;

                response.CantidadPaginas = totalPaginas;
                response.Exito = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar talleres {Message}", ex.Message);
                response.MensajeError = "Error al listar talleres";
            }

            return response;
        }

        public async Task<BaseResponseGeneric<Taller>> Obtener(int id)
        {
            var response = new BaseResponseGeneric<Taller>();

            try
            {
                response.Data = await _repository.Obtener(id);
                response.Exito = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener taller {Message}", ex.Message);
                response.MensajeError = "Error al obtener taller";
            }

            return response;
        }

        public async Task<BaseResponse> Crear(RequestTallerDto request)
        {
            var response = new BaseResponse();

            try
            {
                await _repository.BeginTransactionAsync();

                var taller = _mapper.Map<Taller>(request);

                var instructor = _mapper.Map<Instructor>(request.RequestInstructorDto);
                
                if (!request.RequestInstructorDto.IdInstructor.HasValue || request.RequestInstructorDto.IdInstructor == 0)
                {
                    instructor.CategoriaId = request.CategoriaId;
                    instructor.Id = await _instructorRepository.Crear(instructor);
                    taller.Instructor = instructor;
                }
                else
                    taller.InstructorId = instructor.Id;

                taller.PortadaUrl = await _fileUploader.UploadFileAsync(request.PortadaBase64, request.ArchivoPortada);
                
                taller.TemarioUrl = await _fileUploader.UploadFileAsync(request.TemarioBase64, request.ArchivoTemario);

                await _repository.Crear(taller);

                foreach (var item in request.Temas)
                {
                    var tema = _mapper.Map<Tema>(item);
                    tema.Taller = taller;
                }

                await _repository.Actualizar();
                await _repository.CommitAsync();

                response.Exito = true;
            }
            catch (Exception ex)
            {
                await _repository.RollBackAsync();
                _logger.LogError(ex, "Error al crear taller {Message}", ex.Message);
                response.MensajeError = "Error al crear taller";
            }

            return response;
        }

        public async Task<BaseResponse> Actualizar(int id, RequestTallerDto request)
        {
            var response = new BaseResponse();

            try
            {
                await _repository.BeginTransactionAsync();
                
                var entidad = await _repository.Obtener(id);

                if (entidad == null)
                    throw new InvalidOperationException("No se encontro el registro de Taller");
                _mapper.Map(request, entidad);

                if (!string.IsNullOrEmpty(request.PortadaBase64))
                    entidad.PortadaUrl = await _fileUploader.UploadFileAsync(request.PortadaBase64, request.ArchivoPortada);

                if (!string.IsNullOrEmpty(request.TemarioBase64))
                    entidad.TemarioUrl = await _fileUploader.UploadFileAsync(request.TemarioBase64, request.ArchivoTemario);

                var instructor = _mapper.Map<Instructor>(request.RequestInstructorDto);

                if (!request.RequestInstructorDto.IdInstructor.HasValue || request.RequestInstructorDto.IdInstructor == 0)
                {
                    instructor.CategoriaId = request.CategoriaId;
                    instructor.Id = await _instructorRepository.Crear(instructor);
                    entidad.Instructor = instructor;
                }
                else
                    entidad.InstructorId = instructor.Id;

                entidad.InstructorId = instructor.Id;
                entidad.FechaActualizacion = DateTime.Now;

                await _repository.Actualizar();
                await _repository.CommitAsync();
                
                response.Exito = true;
            }
            catch (Exception ex)
            {
                await _repository.RollBackAsync();
                _logger.LogError(ex, "Error al actualizar taller {Message}", ex.Message);
                response.MensajeError = "Error al actualizar taller";
            }

            return response;
        }

        public async Task<BaseResponse> Eliminar(int id)
        {
            var response = new BaseResponse();

            try
            {
                await _repository.Eliminar(id);
                response.Exito = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar taller {Message}", ex.Message);
                response.MensajeError = "Error al eliminar taller";
            }

            return response;
        }
    }
}