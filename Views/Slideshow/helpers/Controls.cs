// Controls.cs

using System.Windows.Controls;
using System.Windows.Media;

namespace MediaStream.Views.Slideshow.helpers;

public class Controls
{
    // Show all controls (buttons and timer)
    public void ShowControls(Button btnPrevious, Button btnNext, Button btnClose, TextBlock txtTimer)
    {
        btnPrevious.Opacity = 1;
        btnPrevious.IsHitTestVisible = true;

        btnNext.Opacity = 1;
        btnNext.IsHitTestVisible = true;

        btnClose.Opacity = 1;
        btnClose.IsHitTestVisible = true;

        txtTimer.Opacity = 1;
    }

    // Hide all controls (buttons and timer)
    public void HideControls(Button btnPrevious, Button btnNext, Button btnClose, TextBlock txtTimer)
    {
        btnPrevious.Opacity = 0;
        btnPrevious.IsHitTestVisible = false;

        btnNext.Opacity = 0;
        btnNext.IsHitTestVisible = false;

        btnClose.Opacity = 0;
        btnClose.IsHitTestVisible = false;

        txtTimer.Opacity = 0;
    }
}
