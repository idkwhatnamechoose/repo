using UnityEngine;

public class PCInput : MonoBehaviour
{
    public Movement move;
    public bool turnOn = false;
    public Sit st;
    public GameObject uiMobile;
    public UseHand use;
    public AnimatorKubby anim;
    public float jumpForceGreenBootsAndGloves;
	public float jumpForceForPC2 = 2;
	public int useWASD = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		///useWASD = PlayerPrefs.GetInt("useWASD");
      anim = GetComponent<AnimatorKubby>();
        use = GetComponent<UseHand>();
        move = GetComponent<Movement>();
        st = GetComponent<Sit>();
        ///turnOn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(turnOn == true)
        {
			
			if(Input.GetButton("Horizontal"))
                {
                  anim.Animating(true);
			      move.running = true;
                }
                if(Input.GetButtonUp("Horizontal"))
                {
                  anim.Animating(false);
			      move.running = false;
                }
				
			if(useWASD == 0)
			{
				
				if(Input.GetKey(KeyCode.LeftArrow))
                {
                  ///transform.localPosition += -transform.right * move.speed * Time.deltaTime;
                }
                if(Input.GetKey(KeyCode.RightArrow))
                {
                  ///transform.localPosition += transform.right * move.speed * Time.deltaTime;
                }
				if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                  if(move.canJump == true)
                  {
            
                    if(move.boots.type == "green")
                    {
                      GetComponent<AnimatorKubby>().Jump();
                      ///GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForceGreenBootsAndGloves), ForceMode2D.Impulse);
                    }
			        else
			        {
			          GetComponent<AnimatorKubby>().Jump();
			          ///GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, move.jumpForceForPC), ForceMode2D.Impulse);
			        }
                  }
                }
			}
			else
			{
				if(Input.GetKey(KeyCode.A))
                {
                  ///transform.localPosition += -transform.right * move.speed * Time.deltaTime;
                }
                if(Input.GetKey(KeyCode.D))
                {
                  ///transform.localPosition += transform.right * move.speed * Time.deltaTime;
                }
				
			}
			
           ///use.pc = true;
           uiMobile.SetActive(false);
           

           if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.JoystickButton13))
           {
             st.SitDown(false);
           }
           

        }
        
		
		
    }
}
