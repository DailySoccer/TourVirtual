//
//  _MDPGroupModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPGroupModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPGroupModelAttributes {
	__unsafe_unretained NSString *avatarName;
	__unsafe_unretained NSString *avatarThumbnailName;
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *createdDate;
	__unsafe_unretained NSString *deletedDate;
	__unsafe_unretained NSString *fanMe;
	__unsafe_unretained NSString *groupType;
	__unsafe_unretained NSString *hasAvatar;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idGroup;
	__unsafe_unretained NSString *idMatch;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
} MDPGroupModelAttributes;

extern const struct MDPGroupModelRelationships {
	__unsafe_unretained NSString *descriptionGroup;
	__unsafe_unretained NSString *pagedGroupResults;
	__unsafe_unretained NSString *threads;
} MDPGroupModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPPagedGroupsModel;
@class MDPGroupThreadModel;

@interface _MDPGroupModel : NSManagedObject

@property (nonatomic, strong) NSString* avatarName;

//- (BOOL)validateAvatarName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* avatarThumbnailName;

//- (BOOL)validateAvatarThumbnailName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* country;

//- (BOOL)validateCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* createdDate;

//- (BOOL)validateCreatedDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* deletedDate;

//- (BOOL)validateDeletedDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* fanMe;

@property (atomic) BOOL fanMeValue;
- (BOOL)fanMeValue;
- (void)setFanMeValue:(BOOL)value_;

//- (BOOL)validateFanMe:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* groupType;

@property (atomic) int16_t groupTypeValue;
- (int16_t)groupTypeValue;
- (void)setGroupTypeValue:(int16_t)value_;

//- (BOOL)validateGroupType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* hasAvatar;

@property (atomic) BOOL hasAvatarValue;
- (BOOL)hasAvatarValue;
- (void)setHasAvatarValue:(BOOL)value_;

//- (BOOL)validateHasAvatar:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idGroup;

//- (BOOL)validateIdGroup:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMatch;

//- (BOOL)validateIdMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *descriptionGroup;

- (NSMutableSet*)descriptionGroupSet;

@property (nonatomic, strong) MDPPagedGroupsModel *pagedGroupResults;

//- (BOOL)validatePagedGroupResults:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *threads;

- (NSMutableSet*)threadsSet;

@end

@interface _MDPGroupModel (DescriptionGroupCoreDataGeneratedAccessors)
- (void)addDescriptionGroup:(NSSet*)value_;
- (void)removeDescriptionGroup:(NSSet*)value_;
- (void)addDescriptionGroupObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionGroupObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPGroupModel (ThreadsCoreDataGeneratedAccessors)
- (void)addThreads:(NSSet*)value_;
- (void)removeThreads:(NSSet*)value_;
- (void)addThreadsObject:(MDPGroupThreadModel*)value_;
- (void)removeThreadsObject:(MDPGroupThreadModel*)value_;
@end

@interface _MDPGroupModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAvatarName;
- (void)setPrimitiveAvatarName:(NSString*)value;

- (NSString*)primitiveAvatarThumbnailName;
- (void)setPrimitiveAvatarThumbnailName:(NSString*)value;

- (NSString*)primitiveCountry;
- (void)setPrimitiveCountry:(NSString*)value;

- (NSDate*)primitiveCreatedDate;
- (void)setPrimitiveCreatedDate:(NSDate*)value;

- (NSDate*)primitiveDeletedDate;
- (void)setPrimitiveDeletedDate:(NSDate*)value;

- (NSNumber*)primitiveFanMe;
- (void)setPrimitiveFanMe:(NSNumber*)value;

- (BOOL)primitiveFanMeValue;
- (void)setPrimitiveFanMeValue:(BOOL)value_;

- (NSNumber*)primitiveGroupType;
- (void)setPrimitiveGroupType:(NSNumber*)value;

- (int16_t)primitiveGroupTypeValue;
- (void)setPrimitiveGroupTypeValue:(int16_t)value_;

- (NSNumber*)primitiveHasAvatar;
- (void)setPrimitiveHasAvatar:(NSNumber*)value;

- (BOOL)primitiveHasAvatarValue;
- (void)setPrimitiveHasAvatarValue:(BOOL)value_;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdGroup;
- (void)setPrimitiveIdGroup:(NSString*)value;

- (NSString*)primitiveIdMatch;
- (void)setPrimitiveIdMatch:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSMutableSet*)primitiveDescriptionGroup;
- (void)setPrimitiveDescriptionGroup:(NSMutableSet*)value;

- (MDPPagedGroupsModel*)primitivePagedGroupResults;
- (void)setPrimitivePagedGroupResults:(MDPPagedGroupsModel*)value;

- (NSMutableSet*)primitiveThreads;
- (void)setPrimitiveThreads:(NSMutableSet*)value;

@end
