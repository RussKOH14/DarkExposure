using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSkulls : MonoBehaviour

{
    public GameObject skullPrefab; // Prefab of the skull sprite
    public KeyCode upgradeKey = KeyCode.Return; // Key to trigger upgrades

    public Transform skullCenter; // The reference transform for the center of the skulls

    private GameObject[] skulls; // Array to store skull instances
    private int upgradeLevel = 0; // Current upgrade level

    private const int MaxUpgrades = 4; // Total number of upgrades

    // Arrays to store the rotation duration, reappear time, and rotation speed for each upgrade level
    private readonly float[] rotationDurations = { 5f, 7f, 9f, float.PositiveInfinity }; // float.PositiveInfinity for the final level
    private readonly float[] reappearTimes = { 5f, 4f, 3f, 2f };
    private readonly float[] rotationSpeeds = { 50f, 70f, 120f, 180f }; // Updated as per your request

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the array to store the skulls
        skulls = new GameObject[MaxUpgrades];

        // Call the HandleUpgrade() function to activate the skulls immediately
        HandleUpgrade();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the upgrade key press
        if (Input.GetKeyDown(upgradeKey))
        {
            // Increment the upgrade level and ensure it stays within the limits
            upgradeLevel = (upgradeLevel + 1) % (MaxUpgrades + 1);

            // Otherwise, handle the upgrade and rotation behavior
            HandleUpgrade();
        }

        // Rotate the active skulls around the player
        RotateSkullsAroundPlayer();
    }

    // Function to rotate the skulls around the player
    private void RotateSkullsAroundPlayer()
    {
        for (int i = 0; i < upgradeLevel; i++)
        {
            if (skulls[i] != null && skulls[i].activeSelf)
            {
                // Calculate the rotation angle based on the upgrade level
                float angle = Time.time * rotationSpeeds[upgradeLevel - 1] % 360f;

                // Calculate the spawn position based on the angle and the fixed radius (10 units)
                Vector3 spawnPosition = skullCenter.position + Quaternion.Euler(0f, 0f, angle + 360f / upgradeLevel * i) * (Vector3.right * 10f);

                // Update the skull's position to maintain the fixed radius
                skulls[i].transform.position = spawnPosition;
            }
        }
    }

    // Function to handle upgrades
    private void HandleUpgrade()
    {
        // Deactivate all existing skulls
        foreach (GameObject skull in skulls)
        {
            if (skull != null)
                skull.SetActive(false);
        }

        // Activate skulls based on the upgrade level
        for (int i = 0; i < upgradeLevel; i++)
        {
            float angle = 360f / upgradeLevel * i;
            Vector3 spawnPosition = skullCenter.position + Quaternion.Euler(0f, 0f, angle) * (Vector3.right * 10f);
            skulls[i] = Instantiate(skullPrefab, spawnPosition, Quaternion.identity);
        }

        // Start the rotation for the active skulls
        foreach (GameObject skull in skulls)
        {
            if (skull != null)
                skull.SetActive(true);
        }

        // If it's not the final level, start the coroutine for disappear and reappear
        if (upgradeLevel != MaxUpgrades)
        {
            StartCoroutine(DisappearAndReappearSkulls());
        }
    }

    // Coroutine to make skulls disappear and then reappear
    private System.Collections.IEnumerator DisappearAndReappearSkulls()
    {
        // Wait for the rotation duration
        yield return new WaitForSeconds(rotationDurations[upgradeLevel - 1]);

        // Hide the active skulls after the rotation duration
        foreach (GameObject skull in skulls)
        {
            if (skull != null)
                skull.SetActive(false);
        }

        // Wait for the reappear time
        yield return new WaitForSeconds(reappearTimes[upgradeLevel - 1]);

        // Reappear the skulls after the reappear time
        foreach (GameObject skull in skulls)
        {
            if (skull != null)
                skull.SetActive(true);
        }

        // If it's not the final level, start the coroutine again
        if (upgradeLevel != MaxUpgrades)
        {
            StartCoroutine(DisappearAndReappearSkulls());
        }
    }
}