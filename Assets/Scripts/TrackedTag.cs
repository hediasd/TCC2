using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackedTag : LoadableResource {
	
	/*
		SaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSalada	
		AlfaceAlfaceAlfaceAlfaceAlfaceAlfaceAlfaceAlfaceAlfaceAlfaceAlfaceAlfaceAlfaceAlface
		CebolaCebolaCebolaCebolaCebolaCebolaCebolaCebolaCebolaCebolaCebolaCebolaCebolaCebola
		AlfafaAlfafaAlfafaAlfafaAlfafaAlfafaAlfafaAlfafaAlfafaAlfafaAlfafaAlfafaAlfafaAlfafa
		BatataBatataBatataBatataBatataBatataBatataBatataBatataBatataBatataBatataBatataBatata
		BananaBananaBananaBananaBananaBananaBananaBananaBananaBananaBananaBananaBananaBanana


		//https://barcode.tec-it.com/en/PDF417?data=SaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSaladaSalada	
	
	 */
	public string Type;
	public List<PieceModel> Models, Panels;
	public List<PieceEvent> PieceEvents;

	public TrackedTag(){
		Models = new List<PieceModel>();
		Panels = new List<PieceModel>();
		PieceEvents = new List<PieceEvent>();
		//PieceEvents.Add(new PieceEvent());
		//PieceEvents.Add(new PieceEvent());
	}

}
