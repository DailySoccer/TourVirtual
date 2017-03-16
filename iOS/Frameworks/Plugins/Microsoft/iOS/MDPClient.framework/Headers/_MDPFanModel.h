//
//  _MDPFanModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFanModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFanModelAttributes {
	__unsafe_unretained NSString *accountActivated;
	__unsafe_unretained NSString *address;
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *avatarThumbnailUrl;
	__unsafe_unretained NSString *avatarUrl;
	__unsafe_unretained NSString *birthDate;
	__unsafe_unretained NSString *city;
	__unsafe_unretained NSString *contactEmail;
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *deleteDate;
	__unsafe_unretained NSString *disableDate;
	__unsafe_unretained NSString *documentNumber;
	__unsafe_unretained NSString *documentType;
	__unsafe_unretained NSString *fanCardType;
	__unsafe_unretained NSString *fanNumber;
	__unsafe_unretained NSString *fanType;
	__unsafe_unretained NSString *gender;
	__unsafe_unretained NSString *hasAvatar;
	__unsafe_unretained NSString *homeNumber;
	__unsafe_unretained NSString *idActivatedRegister;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *idUserCRM;
	__unsafe_unretained NSString *isActiveMember;
	__unsafe_unretained NSString *isActivePaidFan;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastPolicyAcceptDate;
	__unsafe_unretained NSString *lastUpdate;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *memberNumber;
	__unsafe_unretained NSString *memberSeatId;
	__unsafe_unretained NSString *mobileNumber;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *noSendDataToThirds;
	__unsafe_unretained NSString *noSendInfoData;
	__unsafe_unretained NSString *penya;
	__unsafe_unretained NSString *pictureUrl;
	__unsafe_unretained NSString *preferenceSport;
	__unsafe_unretained NSString *registrationDate;
	__unsafe_unretained NSString *secondName;
	__unsafe_unretained NSString *sendStoreInfoData;
	__unsafe_unretained NSString *source;
	__unsafe_unretained NSString *state;
	__unsafe_unretained NSString *stateCode;
	__unsafe_unretained NSString *surname;
	__unsafe_unretained NSString *title;
	__unsafe_unretained NSString *zip;
} MDPFanModelAttributes;

@interface _MDPFanModel : NSManagedObject

@property (nonatomic, strong) NSNumber* accountActivated;

@property (atomic) BOOL accountActivatedValue;
- (BOOL)accountActivatedValue;
- (void)setAccountActivatedValue:(BOOL)value_;

//- (BOOL)validateAccountActivated:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* address;

//- (BOOL)validateAddress:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* avatarThumbnailUrl;

//- (BOOL)validateAvatarThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* avatarUrl;

//- (BOOL)validateAvatarUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* birthDate;

//- (BOOL)validateBirthDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* city;

//- (BOOL)validateCity:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* contactEmail;

//- (BOOL)validateContactEmail:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* country;

//- (BOOL)validateCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* deleteDate;

//- (BOOL)validateDeleteDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* disableDate;

//- (BOOL)validateDisableDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* documentNumber;

//- (BOOL)validateDocumentNumber:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* documentType;

@property (atomic) uint16_t documentTypeValue;
- (uint16_t)documentTypeValue;
- (void)setDocumentTypeValue:(uint16_t)value_;

//- (BOOL)validateDocumentType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* fanCardType;

@property (atomic) uint16_t fanCardTypeValue;
- (uint16_t)fanCardTypeValue;
- (void)setFanCardTypeValue:(uint16_t)value_;

//- (BOOL)validateFanCardType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* fanNumber;

//- (BOOL)validateFanNumber:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* fanType;

@property (atomic) int16_t fanTypeValue;
- (int16_t)fanTypeValue;
- (void)setFanTypeValue:(int16_t)value_;

//- (BOOL)validateFanType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* gender;

@property (atomic) uint16_t genderValue;
- (uint16_t)genderValue;
- (void)setGenderValue:(uint16_t)value_;

//- (BOOL)validateGender:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* hasAvatar;

@property (atomic) BOOL hasAvatarValue;
- (BOOL)hasAvatarValue;
- (void)setHasAvatarValue:(BOOL)value_;

//- (BOOL)validateHasAvatar:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* homeNumber;

//- (BOOL)validateHomeNumber:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idActivatedRegister;

//- (BOOL)validateIdActivatedRegister:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUserCRM;

//- (BOOL)validateIdUserCRM:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* isActiveMember;

@property (atomic) BOOL isActiveMemberValue;
- (BOOL)isActiveMemberValue;
- (void)setIsActiveMemberValue:(BOOL)value_;

//- (BOOL)validateIsActiveMember:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* isActivePaidFan;

@property (atomic) BOOL isActivePaidFanValue;
- (BOOL)isActivePaidFanValue;
- (void)setIsActivePaidFanValue:(BOOL)value_;

//- (BOOL)validateIsActivePaidFan:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastPolicyAcceptDate;

//- (BOOL)validateLastPolicyAcceptDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdate;

//- (BOOL)validateLastUpdate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* memberNumber;

//- (BOOL)validateMemberNumber:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* memberSeatId;

@property (atomic) int64_t memberSeatIdValue;
- (int64_t)memberSeatIdValue;
- (void)setMemberSeatIdValue:(int64_t)value_;

//- (BOOL)validateMemberSeatId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* mobileNumber;

//- (BOOL)validateMobileNumber:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* noSendDataToThirds;

@property (atomic) BOOL noSendDataToThirdsValue;
- (BOOL)noSendDataToThirdsValue;
- (void)setNoSendDataToThirdsValue:(BOOL)value_;

//- (BOOL)validateNoSendDataToThirds:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* noSendInfoData;

@property (atomic) BOOL noSendInfoDataValue;
- (BOOL)noSendInfoDataValue;
- (void)setNoSendInfoDataValue:(BOOL)value_;

//- (BOOL)validateNoSendInfoData:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* penya;

//- (BOOL)validatePenya:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* pictureUrl;

//- (BOOL)validatePictureUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* preferenceSport;

@property (atomic) uint16_t preferenceSportValue;
- (uint16_t)preferenceSportValue;
- (void)setPreferenceSportValue:(uint16_t)value_;

//- (BOOL)validatePreferenceSport:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* registrationDate;

//- (BOOL)validateRegistrationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* secondName;

//- (BOOL)validateSecondName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* sendStoreInfoData;

@property (atomic) BOOL sendStoreInfoDataValue;
- (BOOL)sendStoreInfoDataValue;
- (void)setSendStoreInfoDataValue:(BOOL)value_;

//- (BOOL)validateSendStoreInfoData:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* source;

//- (BOOL)validateSource:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* state;

//- (BOOL)validateState:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* stateCode;

//- (BOOL)validateStateCode:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* surname;

//- (BOOL)validateSurname:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* title;

@property (atomic) uint16_t titleValue;
- (uint16_t)titleValue;
- (void)setTitleValue:(uint16_t)value_;

//- (BOOL)validateTitle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* zip;

//- (BOOL)validateZip:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPFanModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveAccountActivated;
- (void)setPrimitiveAccountActivated:(NSNumber*)value;

- (BOOL)primitiveAccountActivatedValue;
- (void)setPrimitiveAccountActivatedValue:(BOOL)value_;

- (NSString*)primitiveAddress;
- (void)setPrimitiveAddress:(NSString*)value;

- (NSString*)primitiveAlias;
- (void)setPrimitiveAlias:(NSString*)value;

- (NSString*)primitiveAvatarThumbnailUrl;
- (void)setPrimitiveAvatarThumbnailUrl:(NSString*)value;

- (NSString*)primitiveAvatarUrl;
- (void)setPrimitiveAvatarUrl:(NSString*)value;

- (NSDate*)primitiveBirthDate;
- (void)setPrimitiveBirthDate:(NSDate*)value;

- (NSString*)primitiveCity;
- (void)setPrimitiveCity:(NSString*)value;

- (NSString*)primitiveContactEmail;
- (void)setPrimitiveContactEmail:(NSString*)value;

- (NSString*)primitiveCountry;
- (void)setPrimitiveCountry:(NSString*)value;

- (NSDate*)primitiveDeleteDate;
- (void)setPrimitiveDeleteDate:(NSDate*)value;

- (NSDate*)primitiveDisableDate;
- (void)setPrimitiveDisableDate:(NSDate*)value;

- (NSString*)primitiveDocumentNumber;
- (void)setPrimitiveDocumentNumber:(NSString*)value;

- (NSNumber*)primitiveDocumentType;
- (void)setPrimitiveDocumentType:(NSNumber*)value;

- (uint16_t)primitiveDocumentTypeValue;
- (void)setPrimitiveDocumentTypeValue:(uint16_t)value_;

- (NSNumber*)primitiveFanCardType;
- (void)setPrimitiveFanCardType:(NSNumber*)value;

- (uint16_t)primitiveFanCardTypeValue;
- (void)setPrimitiveFanCardTypeValue:(uint16_t)value_;

- (NSString*)primitiveFanNumber;
- (void)setPrimitiveFanNumber:(NSString*)value;

- (NSNumber*)primitiveFanType;
- (void)setPrimitiveFanType:(NSNumber*)value;

- (int16_t)primitiveFanTypeValue;
- (void)setPrimitiveFanTypeValue:(int16_t)value_;

- (NSNumber*)primitiveGender;
- (void)setPrimitiveGender:(NSNumber*)value;

- (uint16_t)primitiveGenderValue;
- (void)setPrimitiveGenderValue:(uint16_t)value_;

- (NSNumber*)primitiveHasAvatar;
- (void)setPrimitiveHasAvatar:(NSNumber*)value;

- (BOOL)primitiveHasAvatarValue;
- (void)setPrimitiveHasAvatarValue:(BOOL)value_;

- (NSString*)primitiveHomeNumber;
- (void)setPrimitiveHomeNumber:(NSString*)value;

- (NSString*)primitiveIdActivatedRegister;
- (void)setPrimitiveIdActivatedRegister:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSString*)primitiveIdUserCRM;
- (void)setPrimitiveIdUserCRM:(NSString*)value;

- (NSNumber*)primitiveIsActiveMember;
- (void)setPrimitiveIsActiveMember:(NSNumber*)value;

- (BOOL)primitiveIsActiveMemberValue;
- (void)setPrimitiveIsActiveMemberValue:(BOOL)value_;

- (NSNumber*)primitiveIsActivePaidFan;
- (void)setPrimitiveIsActivePaidFan:(NSNumber*)value;

- (BOOL)primitiveIsActivePaidFanValue;
- (void)setPrimitiveIsActivePaidFanValue:(BOOL)value_;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastPolicyAcceptDate;
- (void)setPrimitiveLastPolicyAcceptDate:(NSDate*)value;

- (NSDate*)primitiveLastUpdate;
- (void)setPrimitiveLastUpdate:(NSDate*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveMemberNumber;
- (void)setPrimitiveMemberNumber:(NSString*)value;

- (NSNumber*)primitiveMemberSeatId;
- (void)setPrimitiveMemberSeatId:(NSNumber*)value;

- (int64_t)primitiveMemberSeatIdValue;
- (void)setPrimitiveMemberSeatIdValue:(int64_t)value_;

- (NSString*)primitiveMobileNumber;
- (void)setPrimitiveMobileNumber:(NSString*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSNumber*)primitiveNoSendDataToThirds;
- (void)setPrimitiveNoSendDataToThirds:(NSNumber*)value;

- (BOOL)primitiveNoSendDataToThirdsValue;
- (void)setPrimitiveNoSendDataToThirdsValue:(BOOL)value_;

- (NSNumber*)primitiveNoSendInfoData;
- (void)setPrimitiveNoSendInfoData:(NSNumber*)value;

- (BOOL)primitiveNoSendInfoDataValue;
- (void)setPrimitiveNoSendInfoDataValue:(BOOL)value_;

- (NSString*)primitivePenya;
- (void)setPrimitivePenya:(NSString*)value;

- (NSString*)primitivePictureUrl;
- (void)setPrimitivePictureUrl:(NSString*)value;

- (NSNumber*)primitivePreferenceSport;
- (void)setPrimitivePreferenceSport:(NSNumber*)value;

- (uint16_t)primitivePreferenceSportValue;
- (void)setPrimitivePreferenceSportValue:(uint16_t)value_;

- (NSDate*)primitiveRegistrationDate;
- (void)setPrimitiveRegistrationDate:(NSDate*)value;

- (NSString*)primitiveSecondName;
- (void)setPrimitiveSecondName:(NSString*)value;

- (NSNumber*)primitiveSendStoreInfoData;
- (void)setPrimitiveSendStoreInfoData:(NSNumber*)value;

- (BOOL)primitiveSendStoreInfoDataValue;
- (void)setPrimitiveSendStoreInfoDataValue:(BOOL)value_;

- (NSString*)primitiveSource;
- (void)setPrimitiveSource:(NSString*)value;

- (NSString*)primitiveState;
- (void)setPrimitiveState:(NSString*)value;

- (NSString*)primitiveStateCode;
- (void)setPrimitiveStateCode:(NSString*)value;

- (NSString*)primitiveSurname;
- (void)setPrimitiveSurname:(NSString*)value;

- (NSNumber*)primitiveTitle;
- (void)setPrimitiveTitle:(NSNumber*)value;

- (uint16_t)primitiveTitleValue;
- (void)setPrimitiveTitleValue:(uint16_t)value_;

- (NSString*)primitiveZip;
- (void)setPrimitiveZip:(NSString*)value;

@end
