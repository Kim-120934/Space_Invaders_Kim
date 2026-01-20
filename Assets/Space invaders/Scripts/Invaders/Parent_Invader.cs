using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parent_Invader : MonoBehaviour
{
    public New_Invader[] prefabs;
    public int rows = 5;
    public int cols = 5;
    public float baseSpeed = 5.0f;
    
    public float maxSpeed= 20.0f;
    private int totalInvaders;
    private Vector3 _direction = Vector2.right;
    private int amountKilled = 0;


    private void Awake()
    {
        totalInvaders= this.rows * this.cols;
        // Puntos según la fila 
        int[] rowPoints = { 10, 20, 30, 40, 50 }; // Fila 0 = 10 puntos, Fila 4 = 40 puntos

        for (int row = 0; row < this.rows; row++)
        {
            float width = 2.0f * (this.cols - 1);
            float height = 2.0f * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);

            for (int col = 0; col < this.cols; col++)
            {
                New_Invader invader = Instantiate(this.prefabs[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                invader.transform.localPosition = position;

                // Asigna puntos según la fila
                invader.pointValue = rowPoints[row];
            }
        }
    }

    private void Update()
    {
        int remainingInvaders = 0;
        foreach (Transform invader in this.transform)
        {
            if (invader.gameObject.activeInHierarchy)
            {
                remainingInvaders++;
            }
        }

        float speedMultiplier = (float)totalInvaders / Mathf.Max(remainingInvaders, 1);
        float currentSpeed = Mathf.Clamp(baseSpeed * speedMultiplier, baseSpeed, maxSpeed);

        this.transform.position += _direction * currentSpeed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (_direction == Vector3.right && invader.position.x >= rightEdge.x - 0.5f)
            {
                AdvanceRow();
                break;
            }
            else if (_direction == Vector3.left && invader.position.x <= leftEdge.x + 0.5f)
            {
                AdvanceRow();
                break;
            }
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }
    public void InvaderKilled()
    {
        this.amountKilled++;
        if(this.amountKilled >= this.totalInvaders)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}