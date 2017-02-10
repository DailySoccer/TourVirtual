//
//  _MDPPlayerBasicInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPlayerBasicInfoModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPlayerBasicInfoModelAttributes {
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *birthDate;
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *followersCount;
	__unsafe_unretained NSString *height;
	__unsafe_unretained NSString *idPlayer;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *jerseyNum;
	__unsafe_unretained NSString *joinDate;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *order;
	__unsafe_unretained NSString *pictureUrl;
	__unsafe_unretained NSString *thumbnailUrl;
	__unsafe_unretained NSString *tweetsCount;
	__unsafe_unretained NSString *twitterAccount;
	__unsafe_unretained NSString *twitterBannerUrl;
	__unsafe_unretained NSString *updateable;
	__unsafe_unretained NSString *weight;
} MDPPlayerBasicInfoModelAttributes;

extern const struct MDPPlayerBasicInfoModelRelationships {
	__unsafe_unretained NSString *content;
	__unsafe_unretained NSString *realPosition;
	__unsafe_unretained NSString *realPositionSide;
} MDPPlayerBasicInfoModelRelationships;

@class MDPMediaContentModel;
@class MDPKeyValueObjectModel;
@class MDPKeyValueObjectModel;

@interface _MDPPlayerBasicInfoModel : NSManagedObject

@property (nonatomic, strong) NSString* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* birthDate;

//- (BOOL)validateBirthDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* country;

//- (BOOL)validateCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* followersCount;

@property (atomic) int64_t followersCountValue;
- (int64_t)followersCountValue;
- (void)setFollowersCountValue:(int64_t)value_;

//- (BOOL)validateFollowersCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* height;

//- (BOOL)validateHeight:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlayer;

//- (BOOL)validateIdPlayer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* jerseyNum;

@property (atomic) uint64_t jerseyNumValue;
- (uint64_t)jerseyNumValue;
- (void)setJerseyNumValue:(uint64_t)value_;

//- (BOOL)validateJerseyNum:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* joinDate;

//- (BOOL)validateJoinDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* order;

@property (atomic) int64_t orderValue;
- (int64_t)orderValue;
- (void)setOrderValue:(int64_t)value_;

//- (BOOL)validateOrder:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* pictureUrl;

//- (BOOL)validatePictureUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* thumbnailUrl;

//- (BOOL)validateThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* tweetsCount;

@property (atomic) int64_t tweetsCountValue;
- (int64_t)tweetsCountValue;
- (void)setTweetsCountValue:(int64_t)value_;

//- (BOOL)validateTweetsCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* twitterAccount;

//- (BOOL)validateTwitterAccount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* twitterBannerUrl;

//- (BOOL)validateTwitterBannerUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* updateable;

@property (atomic) BOOL updateableValue;
- (BOOL)updateableValue;
- (void)setUpdateableValue:(BOOL)value_;

//- (BOOL)validateUpdateable:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* weight;

//- (BOOL)validateWeight:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *content;

- (NSMutableSet*)contentSet;

@property (nonatomic, strong) MDPKeyValueObjectModel *realPosition;

//- (BOOL)validateRealPosition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *realPositionSide;

//- (BOOL)validateRealPositionSide:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPlayerBasicInfoModel (ContentCoreDataGeneratedAccessors)
- (void)addContent:(NSSet*)value_;
- (void)removeContent:(NSSet*)value_;
- (void)addContentObject:(MDPMediaContentModel*)value_;
- (void)removeContentObject:(MDPMediaContentModel*)value_;
@end

@interface _MDPPlayerBasicInfoModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAlias;
- (void)setPrimitiveAlias:(NSString*)value;

- (NSDate*)primitiveBirthDate;
- (void)setPrimitiveBirthDate:(NSDate*)value;

- (NSString*)primitiveCountry;
- (void)setPrimitiveCountry:(NSString*)value;

- (NSNumber*)primitiveFollowersCount;
- (void)setPrimitiveFollowersCount:(NSNumber*)value;

- (int64_t)primitiveFollowersCountValue;
- (void)setPrimitiveFollowersCountValue:(int64_t)value_;

- (NSDecimalNumber*)primitiveHeight;
- (void)setPrimitiveHeight:(NSDecimalNumber*)value;

- (NSString*)primitiveIdPlayer;
- (void)setPrimitiveIdPlayer:(NSString*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSNumber*)primitiveJerseyNum;
- (void)setPrimitiveJerseyNum:(NSNumber*)value;

- (uint64_t)primitiveJerseyNumValue;
- (void)setPrimitiveJerseyNumValue:(uint64_t)value_;

- (NSDate*)primitiveJoinDate;
- (void)setPrimitiveJoinDate:(NSDate*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSNumber*)primitiveOrder;
- (void)setPrimitiveOrder:(NSNumber*)value;

- (int64_t)primitiveOrderValue;
- (void)setPrimitiveOrderValue:(int64_t)value_;

- (NSString*)primitivePictureUrl;
- (void)setPrimitivePictureUrl:(NSString*)value;

- (NSString*)primitiveThumbnailUrl;
- (void)setPrimitiveThumbnailUrl:(NSString*)value;

- (NSNumber*)primitiveTweetsCount;
- (void)setPrimitiveTweetsCount:(NSNumber*)value;

- (int64_t)primitiveTweetsCountValue;
- (void)setPrimitiveTweetsCountValue:(int64_t)value_;

- (NSString*)primitiveTwitterAccount;
- (void)setPrimitiveTwitterAccount:(NSString*)value;

- (NSString*)primitiveTwitterBannerUrl;
- (void)setPrimitiveTwitterBannerUrl:(NSString*)value;

- (NSNumber*)primitiveUpdateable;
- (void)setPrimitiveUpdateable:(NSNumber*)value;

- (BOOL)primitiveUpdateableValue;
- (void)setPrimitiveUpdateableValue:(BOOL)value_;

- (NSDecimalNumber*)primitiveWeight;
- (void)setPrimitiveWeight:(NSDecimalNumber*)value;

- (NSMutableSet*)primitiveContent;
- (void)setPrimitiveContent:(NSMutableSet*)value;

- (MDPKeyValueObjectModel*)primitiveRealPosition;
- (void)setPrimitiveRealPosition:(MDPKeyValueObjectModel*)value;

- (MDPKeyValueObjectModel*)primitiveRealPositionSide;
- (void)setPrimitiveRealPositionSide:(MDPKeyValueObjectModel*)value;

@end
