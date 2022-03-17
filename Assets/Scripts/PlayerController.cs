using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public int stamina;
    public float moveSpeed;
    public Transform movePoint;
    public AudioSource sfx_goat1;
    public AudioSource sfx_goat2;

    public Tilemap tilemap;
    public Tile grass;
    public Tile dirt;

    public Vector3Int location;

    public LayerMask stopMovement;

    public BoundsInt area;
    private int sum;
    private int activetime = 1;

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;
    private string swipeDirection = "";

    public float swpieRange;
    public float tapRange;
    //public Animator animator;


    // Start is called before the first frame update
    void Start()
    {        
        // ��Ƭ����
        sum = area.xMax * area.yMax;
        print("Number of tiles: " + sum);

        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
        tilemap.SetTile(Vector3Int.FloorToInt(transform.position), dirt);
        GameManager.S.RefreshStaminText(stamina);
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        // δ�ľ�������δ����ȫ���Ĳ�,��Ϸ������
        // PC ������
        if (stamina > 0 && GetAllGrassTileNumber() > 0)
        {
            if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
                    for (int i = 0; i <= 8 && stamina > 0; i++) {
                        //  ��ײ��⣬δ�����߽�
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, stopMovement) && stamina > 0)
                        {
                            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                            stamina--;
                            GameManager.S.RefreshStaminText(stamina);
                            tilemap.SetTile(Vector3Int.FloorToInt(movePoint.position), dirt);
                            GetAllGrassTileNumber();

                            // ������Ч
                            if (!sfx_goat1.isPlaying && !sfx_goat2.isPlaying)
                            {
                                int p = Random.Range(0, 2);
                                if (p == 0)
                                {
                                    sfx_goat1.Play();
                                }
                                else
                                {
                                    sfx_goat2.Play();
                                }
                            }
                        }
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    for (int i = 0; i <= 8 && stamina > 0; i++)
                    {
                        //  ��ײ��⣬δ�����߽�
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, stopMovement) && stamina > 0)
                        {
                            
                            movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                            stamina--;
                            GameManager.S.RefreshStaminText(stamina);
                            tilemap.SetTile(Vector3Int.FloorToInt(movePoint.position), dirt);
                            GetAllGrassTileNumber();

                            // ������Ч
                            if (!sfx_goat1.isPlaying && !sfx_goat2.isPlaying)
                            {
                                int p = Random.Range(0, 2);
                                if (p == 0)
                                {
                                    sfx_goat1.Play();
                                }
                                else
                                {
                                    sfx_goat2.Play();
                                }
                            }
                        } 
                    }
                }

                //animator.SetBool("moving", false);
            }
            else
            {
                //animator.SetBool("moving", true);
            }
        }

        // �ֻ�������
        if (stamina > 0 && GetAllGrassTileNumber() > 0)
        {
            if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
            {
                if (swipeDirection.Equals("left"))
                {
                    transform.localScale = new Vector3 (-1, 1, 1);
                    for (int i = 0; i <= 8 && stamina > 0; i++)
                    {
                        //  ��ײ��⣬δ�����߽�
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3( -1f, 0f, 0f), 0.2f, stopMovement) && stamina > 0)
                        {
                            movePoint.position += new Vector3( -1f, 0f, 0f);
                            stamina--;
                            GameManager.S.RefreshStaminText(stamina);
                            tilemap.SetTile(Vector3Int.FloorToInt(movePoint.position), dirt);
                            GetAllGrassTileNumber();

                            // ������Ч
                            if (!sfx_goat1.isPlaying && !sfx_goat2.isPlaying)
                            {
                                int p = Random.Range(0, 2);
                                if (p == 0)
                                {
                                    sfx_goat1.Play();
                                }
                                else
                                {
                                    sfx_goat2.Play();
                                }
                            }
                        }
                    }
                }
                else if (swipeDirection.Equals("right"))
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    for (int i = 0; i <= 8 && stamina > 0; i++)
                    {
                        //  ��ײ��⣬δ�����߽�
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), 0.2f, stopMovement) && stamina > 0)
                        {

                            movePoint.position += new Vector3(1f, 0f, 0f);
                            stamina--;
                            GameManager.S.RefreshStaminText(stamina);
                            tilemap.SetTile(Vector3Int.FloorToInt(movePoint.position), dirt);
                            GetAllGrassTileNumber();

                            // ������Ч
                            if (!sfx_goat1.isPlaying && !sfx_goat2.isPlaying)
                            {
                                int p = Random.Range(0, 2);
                                if (p == 0)
                                {
                                    sfx_goat1.Play();
                                }
                                else
                                {
                                    sfx_goat2.Play();
                                }
                            }
                        }
                    }
                }
                else if (swipeDirection.Equals("up"))
                {
                    for (int i = 0; i <= 8 && stamina > 0; i++)
                    {
                        //  ��ײ��⣬δ�����߽�
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), 0.2f, stopMovement) && stamina > 0)
                        {

                            movePoint.position += new Vector3(0f, 1f, 0f);
                            stamina--;
                            GameManager.S.RefreshStaminText(stamina);
                            tilemap.SetTile(Vector3Int.FloorToInt(movePoint.position), dirt);
                            GetAllGrassTileNumber();

                            // ������Ч
                            if (!sfx_goat1.isPlaying && !sfx_goat2.isPlaying)
                            {
                                int p = Random.Range(0, 2);
                                if (p == 0)
                                {
                                    sfx_goat1.Play();
                                }
                                else
                                {
                                    sfx_goat2.Play();
                                }
                            }
                        }
                    }
                }
                else if (swipeDirection.Equals("down"))
                {
                    for (int i = 0; i <= 8 && stamina > 0; i++)
                    {
                        //  ��ײ��⣬δ�����߽�
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), 0.2f, stopMovement) && stamina > 0)
                        {

                            movePoint.position += new Vector3(0f, -1f, 0f);
                            stamina--;
                            GameManager.S.RefreshStaminText(stamina);
                            tilemap.SetTile(Vector3Int.FloorToInt(movePoint.position), dirt);
                            GetAllGrassTileNumber();

                            // ������Ч
                            if (!sfx_goat1.isPlaying && !sfx_goat2.isPlaying)
                            {
                                int p = Random.Range(0, 2);
                                if (p == 0)
                                {
                                    sfx_goat1.Play();
                                }
                                else
                                {
                                    sfx_goat2.Play();
                                }
                            }
                        }
                    }
                }

                //animator.SetBool("moving", false);
            }
            else
            {
                //animator.SetBool("moving", true);
            }
        }

        // δ�ľ������ҳ���ȫ���Ĳݣ���ʤ
        if (stamina > 0 && GetAllGrassTileNumber() <= 0)
        {
            print("Win!");
            GameManager.S.Win(activetime);
            activetime++;
        }
        // �ľ�������δ����ȫ���Ĳ�,ʧ��
        if (stamina == 0 && GetAllGrassTileNumber() > 0)
        {
            print("Lose!");
            GameManager.S.Lose(activetime);
            activetime++;
        }
        // �ľ�������ǡ�ó���ȫ���Ĳ�,��ʤ
        if (stamina == 0 && GetAllGrassTileNumber() == 0)
        {
            print("Hard Win!");
            GameManager.S.Win(activetime);
            activetime++;
        }
        
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {
                if (Distance.x < -swpieRange)
                {
                    // Left
                    stopTouch = true;
                    swipeDirection = "left";
                }
                else if (Distance.x > swpieRange)
                {
                    // Right
                    stopTouch = true;
                    swipeDirection = "right";
                }
                else if (Distance.y > swpieRange)
                {
                    // Up
                    stopTouch = true;
                    swipeDirection = "up";
                }
                else if (Distance.y < -swpieRange)
                {
                    // Down
                    stopTouch = true;
                    swipeDirection = "down";
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            Vector2 Distance = endTouchPosition - startTouchPosition;
            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                // Tap, no response
            }
        }
    }


    //  ��ȡ���вݵ���Ƭ������
    public int GetAllGrassTileNumber()
    {
        int grassnumber = 0;
        // ��������Tilemap
        for (float i = area.xMin - 1.5f; i < area.xMax; i++)
        {
            for (float j = area.yMin - 3.5f; j < area.yMax; j++)
            {
                Vector3Int detectposition = Vector3Int.FloorToInt(new Vector3(i,j,0));
                if (grass == tilemap.GetTile<Tile>(detectposition))
                {
                    grassnumber++;
                    //print(detectposition);
                    //print(grassnumber);
                }
            }
        }
        print(grassnumber);
        return grassnumber;
    }

    public void CheckStatus()
    {
        // δ�ľ������ҳ���ȫ���Ĳݣ���ʤ
        if (stamina > 0 && GetAllGrassTileNumber() <= 0)
        {
            print("Win!");
            GameManager.S.Win(activetime);
            activetime++;
        }        
        // �ľ�������ǡ�ó���ȫ���Ĳ�,��ʤ
        else if (stamina == 0 && GetAllGrassTileNumber() == 0)
        {
            print("Hard Win!");
            GameManager.S.Win(activetime);
            activetime++;
        }
        // �ľ�������δ����ȫ���Ĳ�,ʧ��
        else if (stamina <= 0 && GetAllGrassTileNumber() > 0)
        {
            print("Lose!");
            GameManager.S.Lose(activetime);
            activetime++;
        }
    }
}
