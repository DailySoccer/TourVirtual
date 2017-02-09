//
//  _MDPFanContactExtendedModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFanContactExtendedModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFanContactExtendedModelAttributes {
	__unsafe_unretained NSString *achievements;
	__unsafe_unretained NSString *birthDate;
	__unsafe_unretained NSString *city;
	__unsafe_unretained NSString *friends;
	__unsafe_unretained NSString *groups;
	__unsafe_unretained NSString *isActiveMember;
	__unsafe_unretained NSString *isActivePaidFan;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *messagesThreadId;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *penya;
	__unsafe_unretained NSString *preferenceSport;
	__unsafe_unretained NSString *reputation;
	__unsafe_unretained NSString *secondName;
	__unsafe_unretained NSString *state;
	__unsafe_unretained NSString *surname;
	__unsafe_unretained NSString *virtualGoods;
} MDPFanContactExtendedModelAttributes;

extern const struct MDPFanContactExtendedModelRelationships {
	__unsafe_unretained NSString *fanContanctContactExtended;
} MDPFanContactExtendedModelRelationships;

@class MDPFanContactModel;

@interface _MDPFanContactExtendedModel : NSManagedObject

@property (nonatomic, strong) NSNumber* achievements;

@property (atomic) int64_t achievementsValue;
- (int64_t)achievementsValue;
- (void)setAchievementsValue:(int64_t)value_;

//- (BOOL)validateAchievements:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* birthDate;

//- (BOOL)validateBirthDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* city;

//- (BOOL)validateCity:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* friends;

@property (atomic) int64_t friendsValue;
- (int64_t)friendsValue;
- (void)setFriendsValue:(int64_t)value_;

//- (BOOL)validateFriends:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* groups;

@property (atomic) int64_t groupsValue;
- (int64_t)groupsValue;
- (void)setGroupsValue:(int64_t)value_;

//- (BOOL)validateGroups:(id*)value_ error:(NSError**)error_;

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

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* messagesThreadId;

//- (BOOL)validateMessagesThreadId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* penya;

//- (BOOL)validatePenya:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* preferenceSport;

@property (atomic) uint16_t preferenceSportValue;
- (uint16_t)preferenceSportValue;
- (void)setPreferenceSportValue:(uint16_t)value_;

//- (BOOL)validatePreferenceSport:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* reputation;

@property (atomic) int64_t reputationValue;
- (int64_t)reputationValue;
- (void)setReputationValue:(int64_t)value_;

//- (BOOL)validateReputation:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* secondName;

//- (BOOL)validateSecondName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* state;

//- (BOOL)validateState:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* surname;

//- (BOOL)validateSurname:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* virtualGoods;

@property (atomic) int64_t virtualGoodsValue;
- (int64_t)virtualGoodsValue;
- (void)setVirtualGoodsValue:(int64_t)value_;

//- (BOOL)validateVirtualGoods:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFanContactModel *fanContanctContactExtended;

//- (BOOL)validateFanContanctContactExtended:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPFanContactExtendedModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveAchievements;
- (void)setPrimitiveAchievements:(NSNumber*)value;

- (int64_t)primitiveAchievementsValue;
- (void)setPrimitiveAchievementsValue:(int64_t)value_;

- (NSDate*)primitiveBirthDate;
- (void)setPrimitiveBirthDate:(NSDate*)value;

- (NSString*)primitiveCity;
- (void)setPrimitiveCity:(NSString*)value;

- (NSNumber*)primitiveFriends;
- (void)setPrimitiveFriends:(NSNumber*)value;

- (int64_t)primitiveFriendsValue;
- (void)setPrimitiveFriendsValue:(int64_t)value_;

- (NSNumber*)primitiveGroups;
- (void)setPrimitiveGroups:(NSNumber*)value;

- (int64_t)primitiveGroupsValue;
- (void)setPrimitiveGroupsValue:(int64_t)value_;

- (NSNumber*)primitiveIsActiveMember;
- (void)setPrimitiveIsActiveMember:(NSNumber*)value;

- (BOOL)primitiveIsActiveMemberValue;
- (void)setPrimitiveIsActiveMemberValue:(BOOL)value_;

- (NSNumber*)primitiveIsActivePaidFan;
- (void)setPrimitiveIsActivePaidFan:(NSNumber*)value;

- (BOOL)primitiveIsActivePaidFanValue;
- (void)setPrimitiveIsActivePaidFanValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveMessagesThreadId;
- (void)setPrimitiveMessagesThreadId:(NSString*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSString*)primitivePenya;
- (void)setPrimitivePenya:(NSString*)value;

- (NSNumber*)primitivePreferenceSport;
- (void)setPrimitivePreferenceSport:(NSNumber*)value;

- (uint16_t)primitivePreferenceSportValue;
- (void)setPrimitivePreferenceSportValue:(uint16_t)value_;

- (NSNumber*)primitiveReputation;
- (void)setPrimitiveReputation:(NSNumber*)value;

- (int64_t)primitiveReputationValue;
- (void)setPrimitiveReputationValue:(int64_t)value_;

- (NSString*)primitiveSecondName;
- (void)setPrimitiveSecondName:(NSString*)value;

- (NSString*)primitiveState;
- (void)setPrimitiveState:(NSString*)value;

- (NSString*)primitiveSurname;
- (void)setPrimitiveSurname:(NSString*)value;

- (NSNumber*)primitiveVirtualGoods;
- (void)setPrimitiveVirtualGoods:(NSNumber*)value;

- (int64_t)primitiveVirtualGoodsValue;
- (void)setPrimitiveVirtualGoodsValue:(int64_t)value_;

- (MDPFanContactModel*)primitiveFanContanctContactExtended;
- (void)setPrimitiveFanContanctContactExtended:(MDPFanContactModel*)value;

@end
