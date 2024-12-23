using FitnessProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Core.Entities
{
    public class RoomPriorityEntity
    {
        [Key]
        public uint Id { get; set; }

        public uint CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public CourseEntity Corse { get; set; }
        public uint RoomId { get; set; }
        [ForeignKey(nameof(RoomId))]
        public RoomEntity Room { get; set; }

        public uint Priority { get; set; }

    }
}
