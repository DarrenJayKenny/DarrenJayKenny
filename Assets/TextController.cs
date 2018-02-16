using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {courtyard, walls, gate, sewer, sewerkey, tunnel, deadend, freedom, intro1, intro2, intro3, intro4};
	private States myState;
	
	//collectable booleans
	bool armed = false;
	bool supplied = false;
	bool key = false;
	//decision booleans
	bool aggressive = false;
	bool passive = false;
	bool diplomat = false;
	bool fighter = false;
	bool leader = false;
	bool follower = false;
	bool greedy = false;
	bool giving = false;
	bool faithful = false;
	bool godless = false;
	
	// Use this for initialization
	void Start () {
		myState = States.intro1;
	}
	
	void Update () {
		if (myState == States.intro1)
			intro1();
		else if (myState == States.intro2)
			intro2();
		else if (myState == States.courtyard)
			courtyard();
		else if (myState == States.gate)
			gate();
		else if (myState == States.walls)
			walls();
		else if (myState == States.sewer)
			sewer();
		else if (myState == States.sewerkey)
			sewerkey();
		else if (myState == States.tunnel)
			tunnel();
		else if (myState == States.deadend)
			deadend();
		else if (myState == States.freedom)
			freedom();
	}
	
	void intro1(){
		text.text = "You sit in the barracks with the other soldier of Harken Castle, your comrades desperatly trying to hold back"+
					" the siege outside. Soon it will be your turn.\n\n" +
					"Press A to sharpen your sword, readying yourself for the fight to come.\n\n"  +
					"Press B to wait patiently and enjoy the peaceful time remaining.";
		if (Input.GetKeyDown(KeyCode.A)){
			Debug.Log("Hello.");
			aggressive = true;
			myState = States.intro2;
		} else if (Input.GetKeyDown(KeyCode.B)){
			passive = true;
			myState = States.intro2;
		}
	}

	void intro2(){
		text.text = "Mid preparation you see a fellow solider take a flask from beside your supplies.\n\n"+
					"Press A to beat the man and retrieve your property.\n\n"  +
					"Press B to negotiate and share your drink with the thief.";
		if (Input.GetKeyDown(KeyCode.A)){fighter = true;}
		else if (Input.GetKeyDown(KeyCode.B)){diplomat = true;}
		myState = States.intro3;
	}
	
	void intro3(){
		text.text = "Morale is low amongst the guard, vacant looks in the eyes of once hopeful men and women."+
					"If the fighting starts soon they will surrender.\n\n" +
					"Press A to rally the guard, rousing them with an inspiring speech.\n\n"  +
					"Press B to get the captain and ask him to inspire the men.";
		if (Input.GetKeyDown(KeyCode.A)){leader = true;}
		else if (Input.GetKeyDown(KeyCode.B)){follower = true;}
		myState = States.intro4;
	}
	
	void intro4(){
		text.text = "A young man sits in the far corner, holding a well made shield in both hands."+
					"Press A to take the shield, telling the boy he won't need it.\n\n"  +
					"Press B to offer him to switch your well made sword for his simple blade.";
		if (Input.GetKeyDown(KeyCode.A)){greedy = true;}
		else if (Input.GetKeyDown(KeyCode.B)){giving = true;}
		myState = States.courtyard;
	}
																			
	void courtyard(){
		text.text = "You hear the violent roar of the siege against the castle walls. Your fellow soldiers are mostly dead and rotting," +
					" but you won't be joining them.\n\n" + 
					"Press W to go to Walls. Press G to charge the enemy at the Gates. Press S to check the Sewer grate.";
		if (Input.GetKeyDown(KeyCode.G)){myState = States.gate;}
		else if (Input.GetKeyDown(KeyCode.W)){myState = States.walls;}
		else if (Input.GetKeyDown(KeyCode.S)){myState = States.sewer;}
	}
	
	void gate(){
		text.text = "You watch as dozens of arrows slaughter your men through the breaches in the gate. \n\n" + 
					"Press C to go back to the courtyard to avoid death."; 
		if (Input.GetKeyDown(KeyCode.C)){myState = States.courtyard;}
	}
	
	void sewer(){
		text.text = "You spot the sewer gate, but the damn thing is locked. You need a key! \n\n" + 
					"Press W to go to Walls. Press G to charge the enemy at the Gates.";
		if (Input.GetKeyDown(KeyCode.G)){myState = States.gate;}
		else if (Input.GetKeyDown(KeyCode.W)){myState = States.walls;}
	}
			
	void walls(){
		text.text = "You seen Bormount the Squire, he had latrine duty. Perhaps he has a key to this place!" + 
					"You snatch the key from the runt right as he takes an arrow to the eye. Better him than you.\n\n" +
					"Press S to check the Sewer and escape.";
		if (Input.GetKeyDown(KeyCode.S)){myState = States.sewerkey;}
	}
	
	void sewerkey(){
		text.text = "You rush forward and unlock the gate. \n\n" + 
					"Press T to go to down into the Sewer.";
		if (Input.GetKeyDown(KeyCode.T)){myState = States.tunnel;}
	}
	
	void tunnel(){
		text.text = "You drop down into filth that fills your shoes. Only two directions to go. West or East?\n\n" +
					"Press D for West. Press F for East.";
		if (Input.GetKeyDown(KeyCode.D)){myState = States.deadend;}
		else if (Input.GetKeyDown(KeyCode.F)){myState = States.freedom;}
	}
	
	void deadend(){
		text.text = "You come to a dead end as soldiers begin to flood in overhead. Run! Qucikly!\n\n" +
					"Press F to run like hell!!!";
		if (Input.GetKeyDown(KeyCode.F)){myState = States.freedom;}
	}
	
	void freedom(){
	text.text = "You rush out the sewer to the outside of the fort. Where dozens of soldiers are waiting for you. You fight bravely but feel " +
				"cold steel run you through. As you die you watch as the stronghold goes up in flames.";
	}
}