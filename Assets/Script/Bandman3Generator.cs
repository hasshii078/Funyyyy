using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandman3Generator : MonoBehaviour
{
    //�G�v���n�u
    public GameObject enemyPrefab;
    //���ԊԊu�̍ŏ��l
    public float minTime = 2f;
    //���ԊԊu�̍ő�l
    public float maxTime = 5f;
    //X���W�̍ŏ��l
    public float xMinPosition = -10f;
    //X���W�̍ő�l
    public float xMaxPosition = 10f;
    //Y���W�̍ŏ��l
    public float yMinPosition = 0f;
    //Y���W�̍ő�l
    public float yMaxPosition = 10f;
    //Z���W�̍ŏ��l
    public float zMinPosition = 10f;
    //Z���W�̍ő�l
    public float zMaxPosition = 20f;
    //�G�������ԊԊu
    private float interval;
    //�o�ߎ���
    private float time = 0f;

    //X���W�̍ŏ��l
    public float xMinPosition1 = -10f;
    //X���W�̍ő�l
    public float xMaxPosition1 = 10f;
    //Y���W�̍ŏ��l
    public float yMinPosition1 = 0f;
    //Y���W�̍ő�l
    public float yMaxPosition1 = 10f;
    //Z���W�̍ŏ��l
    public float zMinPosition1 = 10f;
    //Z���W�̍ő�l
    public float zMaxPosition1 = 20f;

    // Start is called before the first frame update
    void Start()
    {
        //���ԊԊu�����肷��
        interval = GetRandomTime();  
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԍv��
        time += Time.deltaTime;

        //�o�ߎ��Ԃ��������ԂɂȂ����Ƃ�(�������Ԃ��傫���Ȃ����Ƃ�)
        if (time > interval)
        {
            //enemy���C���X�^���X������(��������)
            GameObject enemy = Instantiate(enemyPrefab);
            GameObject enemy1 = Instantiate(enemyPrefab);
            //���������G�̈ʒu�������_���ɐݒ肷��
            enemy.transform.position = GetRandomPosition();
            enemy1.transform.position = GetRandomPosition1();
            //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
            time = 0f;
            //���ɔ������鎞�ԊԊu�����肷��
            interval = GetRandomTime();
            Destroy(enemy, 5.0f);
            Destroy(enemy1, 5.0f);
        }
    }

    //�����_���Ȏ��Ԃ𐶐�����֐�
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    //�����_���Ȉʒu�𐶐�����֐�
    private Vector3 GetRandomPosition()
    {
        //���ꂼ��̍��W�������_���ɐ�������
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = Random.Range(yMinPosition, yMaxPosition);
        float z = Random.Range(zMinPosition, zMaxPosition);

        //Vector3�^��Position��Ԃ�
        return new Vector3(x, y, z);      
    }

    private Vector3 GetRandomPosition1()
    {
        float x1 = Random.Range(xMinPosition1, xMaxPosition1);
        float y1 = Random.Range(yMinPosition1, yMaxPosition1);
        float z1 = Random.Range(zMinPosition1, zMaxPosition1);
        return new Vector3(x1, y1, z1);
    }
}