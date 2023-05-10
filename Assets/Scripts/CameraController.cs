using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform mainCamera;

    #region 相机移动参数

    public float moveSpeed   = 1.0f;
    public float rotateSpeed = 90.0f;
    public float shiftRate   = 2.0f; 
    public float minDistance = 0.5f; 

    #endregion

    #region 运动速度和其每个方向的速度分量

    private Vector3 _direction = Vector3.zero;
    private Vector3 _speedForward;
    private Vector3 _speedBack;
    private Vector3 _speedLeft;
    private Vector3 _speedRight;
    private Vector3 _speedUp;
    private Vector3 _speedDown;

    #endregion

    void Start()
    {
        if ( mainCamera == null ) mainCamera = gameObject.transform;
        
    }

    void Update()
    {
        GetDirection();
        
        while ( Physics.Raycast( mainCamera.position, _direction, out var hit, minDistance ) )
        {
            
            var angel     = Vector3.Angle( _direction, hit.normal );
            var magnitude = Vector3.Magnitude( _direction ) * Mathf.Cos( Mathf.Deg2Rad * ( 180 - angel ) );
            _direction += hit.normal * magnitude;
        }

        mainCamera.Translate( _direction * moveSpeed * Time.unscaledDeltaTime, Space.World );
    }

    private void GetDirection()
    {
        #region 加速移动

        if ( Input.GetKeyDown( KeyCode.LeftShift ) ) moveSpeed *= shiftRate;
        if ( Input.GetKeyUp( KeyCode.LeftShift ) ) moveSpeed /= shiftRate;

        #endregion

        #region 键盘移动

        
        _speedForward = Vector3.zero;
        _speedBack = Vector3.zero;
        _speedLeft = Vector3.zero;
        _speedRight = Vector3.zero;
        _speedUp = Vector3.zero;
        _speedDown = Vector3.zero;
        
        if ( Input.GetKey( KeyCode.W ) ) _speedForward = mainCamera.forward;
        if ( Input.GetKey( KeyCode.S ) ) _speedBack = -mainCamera.forward;
        if ( Input.GetKey( KeyCode.A ) ) _speedLeft = -mainCamera.right;
        if ( Input.GetKey( KeyCode.D ) ) _speedRight = mainCamera.right;
        if ( Input.GetKey( KeyCode.E ) ) _speedUp = Vector3.up;
        if ( Input.GetKey( KeyCode.Q ) ) _speedDown = Vector3.down;
        _direction = _speedForward + _speedBack + _speedLeft + _speedRight + _speedUp + _speedDown;

        #endregion

        #region 鼠标旋转

        if ( Input.GetMouseButton( 1 ) )
        {
            
            mainCamera.RotateAround( mainCamera.position, Vector3.up, Input.GetAxis( "Mouse X" ) * rotateSpeed * Time.unscaledDeltaTime );
            mainCamera.RotateAround( mainCamera.position, mainCamera.right, -Input.GetAxis( "Mouse Y" ) * rotateSpeed * Time.unscaledDeltaTime );
            
            _direction = V3RotateAround( _direction, Vector3.up, Input.GetAxis( "Mouse X" ) * rotateSpeed * Time.unscaledDeltaTime );
            _direction = V3RotateAround( _direction, mainCamera.right, -Input.GetAxis( "Mouse Y" ) * rotateSpeed * Time.unscaledDeltaTime );
        }

        #endregion
    }

    
    public Vector3 V3RotateAround( Vector3 source, Vector3 axis, float angle )
    {
        var q = Quaternion.AngleAxis( angle, axis ); 
        return q * source; 
    }
}