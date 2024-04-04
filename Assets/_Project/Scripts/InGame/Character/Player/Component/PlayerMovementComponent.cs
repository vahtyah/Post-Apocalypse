using UnityEngine;

public class PlayerMovementComponent
{
    private Player player;
    private Camera mainCamera;

    private Vector2 inputDir;
    float cameraDistance = 10f;

    public PlayerMovementComponent(Player player)
    {
        this.player = player;
        mainCamera = Camera.main;
    }

    private Vector2 GetInput()
    {
        inputDir.x = InputManager.HorizontalMovement();
        inputDir.y = InputManager.VerticalMovement();
        return inputDir;
    }

    public void Iterate()
    {
        inputDir = GetInput();
        Move();
        Look();
        player.Animation.BlendMove(inputDir.x, inputDir.y);
    }

    private void Move()
    {
        var speed = player.Stats.Speed * Time.fixedDeltaTime;
        player.GetRb().velocity = new Vector3(inputDir.x * speed, player.GetRb().velocity.y, inputDir.y * speed);
    }

    private void Look()
    {
        var mousePos =
            mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDistance));
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, Mathf.Infinity, player.GetGroundMask()))
        {
            Vector3 hitPoint = hit.point;
            InGameManager.Instance.GetReticle().position = hitPoint;
            player.transform.LookAt(hitPoint);
            player.transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y, 0);
        }
        else
        {
            player.transform.LookAt(mousePos);
            player.transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y, 0);
        }
    }

    public void SetPosition(Vector3 position) => player.transform.position = position;
}