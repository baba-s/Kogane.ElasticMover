# UniElasticMover

ぼよよんと出る動きを管理するクラス

## 使用例

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    public ElasticMover m_elasticMover = new ElasticMover
    {
        Deceleration = 0.9f,
        Friction     = 0.1f,
    };

    private void Update()
    {
        m_elasticMover.TargetScale = Input.GetKey( KeyCode.Space ) ? 1.2f : 1;

        m_elasticMover.Update( () => Debug.Log( "完了" ) );

        transform.localScale = new Vector3
        (
            m_elasticMover.Scale,
            m_elasticMover.Scale,
            1
        );
    }
}
```

![Image (29)](https://user-images.githubusercontent.com/6134875/84899852-35363b00-b0e4-11ea-8abd-3b60d4d2db87.gif)

