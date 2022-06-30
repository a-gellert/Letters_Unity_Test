using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField _widthText;
    [SerializeField] private TMPro.TMP_InputField _heightText;
    [SerializeField] private Animator _emptyInput;
    [SerializeField] private Animator _emptyField;


    [SerializeField] private Field _field;

    private int _width;
    private int _height;
    private bool _isFieldNotEmpty = false;

    public void OnGenerate()
    {
        if (Validate())
        {
            _field.GenerateField(_width, _height);
            _isFieldNotEmpty = true;
        }
    }
    public void OnRemix()
    {
        if (_isFieldNotEmpty)
        {
            _field.RemixField();
            return;
        }
        _emptyField.Play("ShowWarning");
    }

    private bool Validate()
    {
        int.TryParse(_widthText.text.ToString(), out int w);
        int.TryParse(_heightText.text.ToString(), out int h);

        if (w == 0 || h == 0)
        {
            _emptyInput.Play("ShowWarning");
            return false;
        }

        if (w > 10)
        {
            w = 10;
            _widthText.text = w.ToString();
        }
        if (h > 10)
        {
            h = 10;
            _heightText.text = h.ToString();
        }
        _width = w;
        _height = h;
        return true;
    }
}
