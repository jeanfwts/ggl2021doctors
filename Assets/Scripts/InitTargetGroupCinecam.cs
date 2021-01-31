using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTargetGroupCinecam : MonoBehaviour
{

    // DO NOT USE IT !!!!

    public float playerRadius = 2f;
    public float playerWeight = 1f;
    public float projectilesRadius = 0.5f;
    public float projectilesWeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Cinemachine.CinemachineTargetGroup group = GetComponent<Cinemachine.CinemachineTargetGroup>();

        Debug.Log("fetch group: " + group);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("projectile");

        Debug.Log("number of projectiles: " + projectiles.Length);

        Cinemachine.CinemachineTargetGroup.Target target = new Cinemachine.CinemachineTargetGroup.Target();
        target.target = player.transform;
        target.weight = playerWeight;
        target.radius = playerRadius;

        group.m_Targets = new Cinemachine.CinemachineTargetGroup.Target[1 + projectiles.Length];
        group.m_Targets.SetValue(target, 0);

        Debug.Log("set player target: " + target);

        for (int i = 0; i < projectiles.Length; i++)
        {
            target = new Cinemachine.CinemachineTargetGroup.Target();
            target.target = projectiles[i].transform;
            target.weight = projectilesWeight;
            target.radius = projectilesRadius;
            group.m_Targets.SetValue(target, 1 + i);
        }
    }

}
