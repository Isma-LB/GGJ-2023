using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		[SerializeField] LayerMask playerLayer;
		[SerializeField] GameObject targetSelector;
		public float alcance = 16f;
		Collider2D jugador;
		bool seleccionable = true;
		[SerializeField] List<GameObject> PuntosControl;


		IAstarAI ai;

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {
			if (target != null && ai != null) ai.destination = target.position;
			if(target == null && seleccionable)
            {
				SeleccionarObjetivo();
			}

        }
		private void SeleccionarObjetivo()
		{
			jugador = Physics2D.OverlapCircle(targetSelector.transform.position, alcance, playerLayer);
			if(jugador != null)
            {
				//QuitarTarget();
				target = jugador.transform;
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (targetSelector == null)
				return;

			Gizmos.DrawWireSphere(targetSelector.transform.position, alcance);
		}

		public void QuitarTarget()
        {
			StartCoroutine(TimerOlvidar());
		}

		public IEnumerator TimerOlvidar()
        {
			seleccionable = false;
			yield return new WaitForSeconds(10);
            target = PuntosControl[0].transform;
            target = null;
            StartCoroutine(TimerEscape());

        }

		public IEnumerator TimerEscape()
        {
			yield return new WaitForSeconds(5);
			seleccionable = true;

		}
	}
}
