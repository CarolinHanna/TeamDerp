using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class RoomCreator : MonoBehaviour {

	List<Room> rooms = new List<Room>();

	[SerializeField] Room[] room_prefabs;
	[SerializeField] Room final_room;
	[SerializeField] GameObject door_blocker = null;
	[SerializeField] float room_distance = 1;
	[SerializeField] Vector3 door_offset = Vector2.zero;
	[SerializeField] float door_rotation;
	[SerializeField] byte max_num_rooms = 1;


	void Start(){
		for(byte i = 0;i < max_num_rooms;i++){
			if(rooms.Count == 0){
				Room temp_room = new Room(Vector3.zero);
				rooms.Add(temp_room);
			}
			else{
				List<Room.doors> doors = new List<Room.doors>();
				doors.Add(Room.doors.back);
				doors.Add(Room.doors.front);
				doors.Add(Room.doors.left);
				doors.Add(Room.doors.right);
				//print_debug(doors);
				Room.doors random_door = doors[Random.Range(0, doors.Count)];
				Vector3 temp_coord = rooms[rooms.Count-1].coord;
				bool looping = true;
				while(looping){ //scary af
					temp_coord = rooms[rooms.Count-1].coord;
					random_door = doors[Random.Range(0, doors.Count)];
						if(random_door == Room.doors.back)
							temp_coord.z += room_distance;
						else if(random_door == Room.doors.front)
							temp_coord.z -= room_distance;
						else if(random_door == Room.doors.left)
							temp_coord.x -= room_distance;
						else if(random_door == Room.doors.right)
							temp_coord.x += room_distance;
						looping = false;
						foreach(Room room in rooms){
							if(room.coord == temp_coord){
								doors.Remove(random_door);
								looping = true;
							}
						}
				}
				rooms[rooms.Count-1].open_door(random_door);
				Room temp_room = new Room(temp_coord, Room.get_oposite(random_door));
				rooms.Add(temp_room);
			}
		}
		create_rooms();
	}

	void create_rooms(){
		for(byte i=0;i < max_num_rooms;i++){
			Room new_room;
			if(i == max_num_rooms -1){
				new_room =  (Room)Instantiate(final_room, rooms[i].coord, Quaternion.identity);
				new_room.coord = rooms[i].coord;
				new_room.back = rooms[i].back;
				new_room.front = rooms[i].front;
				new_room.left = rooms[i].left;
				new_room.right = rooms[i].right;
				return;
			}
			new_room =  (Room)Instantiate(room_prefabs[Random.Range(0,room_prefabs.Length)], rooms[i].coord, Quaternion.identity);
			new_room.coord = rooms[i].coord;
			new_room.back = rooms[i].back;
			new_room.front = rooms[i].front;
			new_room.left = rooms[i].left;
			new_room.right = rooms[i].right;

			if(!new_room.back){
				Instantiate(door_blocker, new Vector3(new_room.coord.x, new_room.coord.y + door_offset.y, new_room.coord.z + door_offset.z), door_blocker.transform.rotation);
			}
			if(!new_room.front){
				Instantiate(door_blocker, new Vector3(new_room.coord.x, new_room.coord.y + door_offset.y, new_room.coord.z - door_offset.z), door_blocker.transform.rotation);
			}
			if(!new_room.left){
				Instantiate(door_blocker, new Vector3(new_room.coord.x  - door_offset.x, new_room.coord.y + door_offset.y, new_room.coord.z)
					, Quaternion.Euler(0,90,0));
			}
			if(!new_room.right){
				Instantiate(door_blocker, new Vector3(new_room.coord.x  + door_offset.x, new_room.coord.y + door_offset.y, new_room.coord.z)
					, Quaternion.Euler(0,90,0));
			}
		}
	}

	void print_debug(List<Room.doors> derp){
//		foreach(Room.doors test in derp){
//			print(test.ToString());
//		}
		print(derp[Random.Range(0,derp.Count)]);
	}
	
}

