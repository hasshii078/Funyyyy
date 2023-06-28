using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadScene���g�����߂ɕK�v

public class BandmanController : MonoBehaviour
{
    public GameObject breakEffect; //�|�����Ƃ��̃G�t�F�N�g
    enum ShotType
    {
        NONE = 0,
        AIM,            // �v���C���[��_��
        THREE_WAY,      // �R����
    }

    [System.Serializable]
    struct ShotData
    {
        public int frame;
        public ShotType type;
        public EnemyShot bullet;
    }

    // �V���b�g�f�[�^
    [SerializeField] ShotData shotData = new ShotData { frame = 60, type = ShotType.NONE, bullet = null };

    GameObject playerObj = null;    // �v���C���[�I�u�W�F�N�g
    int shotFrame = 0;              // �t���[��


    // Start is called before the first frame update
    void Start()
    {
        // �v���C���[�I�u�W�F�N�g���擾����
        switch (shotData.type)
        {
            case ShotType.AIM:
                playerObj = GameObject.Find("toonkigou");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
    }
    public void OnpuHit1()
    {
        Destroy(this.gameObject);
        //audioSource.PlayOneShot(bakuhatsu);
        GenerateEffect();�@//�G�t�F�N�g����
    }

    void GenerateEffect()
    {
        //�G�t�F�N�g����
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //�G�t�F�N�g��������ꏊ������
        effect.transform.position = gameObject.transform.position;
    }
    void Shot()
    {
        ++shotFrame;
        if (shotFrame > shotData.frame)
        {
            switch (shotData.type)
            {
                // �v���C���[��_��
                case ShotType.AIM:
                    {
                        if (playerObj == null) { break; }
                        EnemyShot bullet = (EnemyShot)Instantiate(
                            shotData.bullet,
                            transform.position,
                            Quaternion.identity
                        );
                        bullet.SetMoveVec(playerObj.transform.position - transform.position);
                        Destroy(bullet.gameObject,7.0f);
                    }
                    break;

                // �R����
                case ShotType.THREE_WAY:
                    {
                        EnemyShot bullet = (EnemyShot)Instantiate(
                            shotData.bullet,
                            transform.position,
                            Quaternion.identity
                        );
                        bullet = (EnemyShot)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                        bullet.SetMoveVec(Quaternion.AngleAxis(15, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                        bullet = (EnemyShot)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                        bullet.SetMoveVec(Quaternion.AngleAxis(-15, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                        Destroy(bullet.gameObject, 7.0f);
                    }
                    break;
            }

            shotFrame = 0;
        }
       
    }
}
