using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class BachAttackHard : MonoBehaviour
{
    public static float timelimit = 0f;//�����U���p�Ɏ��ԑ���
    private Animator anim;

    public GameObject bach;//�o�b�n�i�[�p
    //public Sprite Bachbright;//�o�b�n�U�����̉摜
    //public Sprite BachNormal;//�o�b�n�ʏ�摜
    SpriteRenderer BachSprite;//�o�b�n�̉摜�̎�ނ�ς��邽�ߗp��

    public GameObject player;//��l���i�[
    Transform playerTransform;//��l���̍��W�Ȃ�

    public GameObject laser;//���[�U�[
    private GameObject laserobj;
    public Transform laserpoint;//���[�U�[�̔��ˌ�������肷�邽�߂ɁA�o�b�n�ړ��������_�ł̎�l���̍��W���擾����

    public GameObject organ;//�p�C�v�I���K��
    private GameObject organobj;
    public int count = 0;//�p�C�v�𗎂Ƃ����񐔂𐔂���

    public GameObject end;//�����U���̂��
    public GameObject endobj;

    public float speed = 0.5f;//�o�b�n�ړ��X�s�[�h
    public int AttackType = 0;//�o�b�n���ǂ̍U�������邩���߂�ϐ�
    //�P�F��ʒ[��������@�Q�F�p�C�v�I���K������ 3:��]�ːi

    private int[,] posi = new int[2, 2] { { -20, 20 }, { 3, 0 } };//�r�[�����ˎ���x,y���W���B{{x1,x2},{y1,y2}}�B

    Vector3 movePosition;//�r�[�����ˎ��̃o�b�n���s���ꏊ

    public int Attacking = 0;//�o�b�n���U���O���U�������U���ォ(0,1,2)

    // Start is called before the first frame update
    void Start()
    {
        //BachSprite = bach.GetComponent<SpriteRenderer>();//�o�b�n�̃X�v���C�g���擾
        anim = bach.GetComponent<Animator>();

        playerTransform = player.transform;//��l���̍��W���擾
        movePosition = new Vector3(posi[0, Random.Range(0, 2)], posi[1, Random.Range(0, 2)], 0);//�r�[�����̈ړ��ꏊ��\�ߌ��߂�

        laser = Resources.Load<GameObject>("Laser");//Resources�t�H���_����Laser�v���n�u��ǂݍ���
        organ = Resources.Load<GameObject>("Organ");//Resources�t�H���_����Organ�v���n�u��ǂݍ���
        end = Resources.Load<GameObject>("End");//Resources�t�H���_����End�v���n�u��ǂݍ���

        laserpoint = laser.transform;//�悭�킩��Ȃ������̈ꕶ���Ȃ��Ɠ����Ȃ��̂ŏ����Ȃ�

    }

    // Update is called once per frame
    void Update()
    {

        timelimit += Time.deltaTime;//���Ԃ𑪂�


        if (timelimit < 30)//20�b�o�܂ł͂���
        {
            //��l����������
            if (this.bach.transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(3, 3, 1);
            }
            else
            {
                transform.localScale = new Vector3(-3, 3, 1);
            }

            //�����U�����łȂ��Ȃ�V�����U�����Z�b�g
            if (AttackType == 0)
            {
                movePosition = new Vector3(posi[0, Random.Range(0, 2)], posi[1, Random.Range(0, 2)], 0);//�r�[�����̈ړ��ꏊ��\�ߌ��߂�
                AttackType = Random.Range(1, 3);//(n,m)��n�ȏ�m�����̃����_���Ȑ���
            }
            else if (AttackType == 1) //���[�U�[�U�����I�΂ꂽ�ꍇ
            {
                Attack_1();
            }
            else if (AttackType == 2)
            {
                Attack_2();
            }
            else if (AttackType == 3)
            {
                Attack_3();
            }
        }
        else if (timelimit >= 30)//30�b�o�����瑦��
        {
            Attack_toDeath();
            timelimit = 0f;
        }

    }

    //���[�U�[�U��
    void Attack_1()
    {
        //�ړI�n�Ɉړ�����
        this.bach.transform.position = Vector3.MoveTowards(bach.transform.position, movePosition, speed);
        anim.SetBool("bright", true);//�o�b�n������A�j���Ɉڍs
        if (movePosition == this.bach.transform.position)
        {
            //�܂��r�[�������ĂȂ�(Attacking==0)�Ȃ猂��
            if (Attacking == 0)
            {
                Attacking = 1;//��Ԃ��U�����ɐݒ�

                //BachSprite.sprite = Bachbright;//�o�b�n�������Ă�摜�ɕς���
                laserobj = Instantiate(laser, this.bach.transform.position, Quaternion.identity);//���[�U�[���I�u�W�F�N�g�ɂ��ĉ�ʂɕ\��
                laserpoint.position = playerTransform.position;//���[�U�[�̖ړI�n����������l���̍��W���������̂ɂ��Ă݂�B���̎��_�ō��W�����A�r�[�����˒�������l���̍��W���X�V���Ȃ��悤�ɂ���B
                Invoke("DestroyLaser", 2.0f);
            }
        }
        //�U���I��(AttackType=0�ɂ���)
        if (Attacking == 2)
        {
            anim.SetBool("bright", false);
            //BachSprite.sprite = BachNormal;//�o�b�n�̉摜��߂�
            AttackType = 0;//�U���O�̏�Ԃ�
            Attacking = 0;//��Ԃ��U���O�ɐݒ�
        }

    }
    //���[�U�[�̌��ɂȂ�e��������悤�ɂ���
    void DestroyLaser()
    {
        Destroy(laserobj);//�e����
        Attacking = 2;//��Ԃ��U���I���ɐݒ�
    }

    //�p�C�v�����U��
    void Attack_2()
    {
        this.bach.transform.position = Vector3.MoveTowards(bach.transform.position, new Vector3(0, 20, 0), speed);//�o�b�n��Ɉړ�
                                                                                                                  //Attacking = 1;//��Ԃ��U�����ɐݒ�

        if (Attacking == 0)
        {
            Attacking = 1;

            Vector3 posi = new Vector3(Random.Range(-10, 10), 20, 0);//�p�C�v���o��������W
            organobj = Instantiate(organ, posi, Quaternion.identity);//�p�C�v���I�u�W�F�N�g�ɂ��ĉ�ʂɕ\��
            Invoke("DestroyOrgan", 1.0f);
        }

        //�U���I��(AttackType=0�ɂ���)
        if (Attacking == 2)
        {
            AttackType = 0;//�U���O�̏�Ԃ�
            Attacking = 0;//��Ԃ��U���O�ɐݒ�
        }
    }
    //�p�C�v��������悤�ɂ���
    void DestroyOrgan()
    {
        Destroy(organobj);//�e����
        Attacking = 2;
        //count++;
        //Debug.Log(count);
    }
    //��]�ːi
    void Attack_3()
    {
        float bachpositionY = 0;//��l���Ɠ���y���W�Ɉړ����邽�߁A��l����y���W���擾����
        Vector3 bachstart = new Vector3(-30, 0, 0);//�ːi�J�n�ʒu
        Vector3 bachgole = new Vector3(30, 0, 0);//�I���ʒu
        if (Attacking == 0)
        {
            bachpositionY = playerTransform.position.y;
            bachstart = new Vector3(-30, bachpositionY, 0);

            Attacking = 1;//Attacking=0�̎��Ɏ�l����y���W���擾�A��������ω����Ȃ��悤�ɂP�ɕς���
        }
        if (Attacking == 1)
        {
            this.bach.transform.position = Vector3.MoveTowards(bach.transform.position, bachstart, speed * 2);//�o�b�n��ʒ[�Ɉړ�
            if (this.bach.transform.position == bachstart)
            {
                Attacking = 2;//�ړ�������m�点��
            }
        }
        if (Attacking == 2)
        {
            bachgole = new Vector3(30, bachpositionY, 0);
            this.bach.transform.Rotate(0, 0, 20);
            this.bach.transform.position = Vector3.MoveTowards(bach.transform.position, bachgole, speed * 2);//��]���Ȃ���ˌ�
            if (this.bach.transform.position == bachgole)
            {
                Attacking = 3;//�U���I��
            }
        }
        //�U���I��
        if (Attacking == 3)
        {
            this.bach.transform.rotation = Quaternion.Euler(0, 0, 0);//�p�x�����ɖ߂�
            AttackType = 0;
            Attacking = 0;
        }

    }

    //�����U��
    void Attack_toDeath()
    {
        this.bach.transform.position = new Vector3(0, 10, 0);
        this.bach.transform.Rotate(0, 0, 20);
        if (Attacking != 4)
        {
            endobj = Instantiate(end, new Vector3(0, 10, 0), Quaternion.identity);//�I�u�W�F�N�g�ɂ��ĉ�ʂɕ\��
            Attacking = 4;//������������Ȃ��悤�ɂ���
            Attacking = 0;
        }
    }
}

