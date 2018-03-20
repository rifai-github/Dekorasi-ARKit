using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterModal : BaseModal
{
    [SerializeField]
    private InputField _FullNameInput;
    [SerializeField]
    private InputField _EmailInput;
    [SerializeField]
    private InputField _PhoneInput;
    [SerializeField]
    private InputField _UsernameInput;
    [SerializeField]
    private InputField _PasswordInput;
    [SerializeField]
    private InputField _RePasswordInput;
    [SerializeField]
    private Button _RegisterButton;

    private static RegisterModal _Instance;

    public static RegisterModal Instance()
    {
        if (_Instance == null)
        {
            _Instance = FindObjectOfType<RegisterModal>();

            if (_Instance == null)
            {
                Debug.LogError("there is no RegisterModal in the system");
            }
        }
        return _Instance;
    }

    public override void OpenModal()
    {
        base.OpenModal();
    }
}
