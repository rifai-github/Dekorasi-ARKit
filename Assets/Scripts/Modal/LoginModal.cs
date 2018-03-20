using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginModal : BaseModal
{
    [SerializeField]
    private InputField _UsernameInput;
    [SerializeField]
    private InputField _PasswordInput;
    [SerializeField]
    private Toggle _SavePasswordTogle;
    [SerializeField]
    private Button _LoginButton;
    [SerializeField]
    private Button _RegisterButton;

    private static LoginModal _Instance;

    public static LoginModal Instance()
    {
        if (_Instance == null)
        {
            _Instance = FindObjectOfType<LoginModal>();

            if (_Instance == null)
            {
                Debug.LogError("there is no LoginModal in the system");
            }
        }
        return _Instance;
    }

    public override void OpenModal()
    {
        base.OpenModal();
    }
}
