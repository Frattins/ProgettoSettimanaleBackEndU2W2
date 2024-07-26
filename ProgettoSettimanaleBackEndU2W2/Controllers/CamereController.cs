using Microsoft.AspNetCore.Mvc;
using ProgettoSettimanaleBackEndU2W2.Models;
using ProgettoSettimanaleBackEndU2W2.DAO;
using ProgettoSettimanaleBackEndU2W2.Interface;

[Route("api/[controller]")]
[ApiController]
public class CamereController : ControllerBase
{
    private readonly ICameraDao _cameraDao;

    public CamereController(ICameraDao cameraDao)
    {
        _cameraDao = cameraDao;
    }

    [HttpGet]
    public IActionResult GetAllRooms()
    {
        return Ok(_cameraDao.GetAllRooms());
    }

    [HttpGet("{id}")]
    public IActionResult GetRoomById(int id)
    {
        var room = _cameraDao.GetRoomById(id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }

    [HttpPost]
    public IActionResult AddRoom(Room room)
    {
        _cameraDao.AddRoom(room);
        return CreatedAtAction(nameof(GetRoomById), new { id = room.RoomID }, room);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRoom(int id, Room room)
    {
        if (id != room.RoomID)
        {
            return BadRequest();
        }
        _cameraDao.UpdateRoom(room);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRoom(int id)
    {
        _cameraDao.DeleteRoom(id);
        return NoContent();
    }
}
