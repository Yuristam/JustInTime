/*using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.WebApp.Controllers
{
        public class EventsController : ControllerBase
        {
            private readonly NotesDbContext _context;

            public EventsController(NotesDbContext context)
            {
                _context = context;
            }

            // GET: api/CalendarEvents
            [HttpGet]
            public async Task<ActionResult<IEnumerable<CalendarEvent>>> GetEvents([FromQuery] DateTime start, [FromQuery] DateTime end)
            {
                return await _context.Events
                    .Where(e => !((e.End <= start) || (e.Start >= end)))
                    .ToListAsync();
            }

            // GET: api/Events/5
            [HttpGet("{id}")]
            public async Task<ActionResult<CalendarEvent>> GetCalendarEvent(int id)
            {
                var calendarEvent = await _context.Events.FindAsync(id);

                if (calendarEvent == null)
                {
                    return NotFound();
                }

                return calendarEvent;
            }

            // PUT: api/Events/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutCalendarEvent(int id, CalendarEvent calendarEvent)
            {
                if (id != calendarEvent.Id)
                {
                    return BadRequest();
                }

                _context.Entry(calendarEvent).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendarEventExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // POST: api/Events
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<CalendarEvent>> PostCalendarEvent(CalendarEvent calendarEvent)
            {
                _context.Events.Add(calendarEvent);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCalendarEvent", new { id = calendarEvent.Id }, calendarEvent);
            }

            // DELETE: api/Events/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCalendarEvent(int id)
            {
                var calendarEvent = await _context.Events.FindAsync(id);
                if (calendarEvent == null)
                {
                    return NotFound();
                }

                _context.Events.Remove(calendarEvent);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool CalendarEventExists(int id)
            {
                return _context.Events.Any(e => e.Id == id);
            }

            // PUT: api/Events/5/move
            [HttpPut("{id}/move")]
            public async Task<IActionResult> MoveEvent([FromRoute] int id, [FromBody] EventMoveParams param)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var @event = await _context.Events.SingleOrDefaultAsync(m => m.Id == id);
                if (@event == null)
                {
                    return NotFound();
                }

                @event.Start = param.Start;
                @event.End = param.End;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendarEventExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // PUT: api/Events/5/color
            [HttpPut("{id}/color")]
            public async Task<IActionResult> SetEventColor([FromRoute] int id, [FromBody] EventColorParams param)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var @event = await _context.Events.SingleOrDefaultAsync(m => m.Id == id);
                if (@event == null)
                {
                    return NotFound();
                }

                @event.Color = param.Color;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendarEventExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
        }


        public class EventMoveParams
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }

        public class EventColorParams
        {
            public string Color { get; set; }
        }
    }
*/