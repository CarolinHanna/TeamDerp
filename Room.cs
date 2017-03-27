using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour{

	public Vector3 coord;
	public bool back = false;
	public bool front = false;
	public bool left = false;
	public bool right = false;

	public Room(Vector3 coord){
		this.coord = coord;
	}

	public Room(Vector3 coord, bool back, bool front, bool left, bool right){
		this.coord = coord;
		this.back = back;
		this.front = front;
		this.left = left;
		this.right = right;
	}

	public Room(Vector3 coord, doors door){
		this.coord = coord;

		if(door == doors.back)
			this.back = true;
		else if(door == doors.front)
			this.front = true;
		else if(door == doors.left)
			this.left = true;
		else if(door == doors.right)
			this.right = true;
	}

	public void open_door(doors door){
		if(door == doors.back)
			this.back = true;
		else if(door == doors.front)
			this.front = true;
		else if(door == doors.left)
			this.left = true;
		else if(door == doors.right)
			this.right = true;
	}

	static public doors get_oposite(doors door){
		if(door == doors.back)
			return doors.front;
		else if(door == doors.front)
			return doors.back;
		else if(door == doors.left)
			return doors.right;
		else if(door == doors.right)
			return doors.left;

		return doors.error;
	}

	public enum doors{
		back,
		front,
		left,
		right,
		error
	}



}
