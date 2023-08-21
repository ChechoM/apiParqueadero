using Parqueadero.Data.Dto;

namespace Parqueadero.Data.Mock
{
    public interface IMockParqueaderoDto
    {
        public List<ParqueaderoDto> getMockParqueadero();
        public List<string> getComentarios();
    }
}
