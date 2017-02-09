//
//  _MDPPlayerModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPlayerModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPlayerModelAttributes {
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *birthDate;
	__unsafe_unretained NSString *birthPlace;
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *followersCount;
	__unsafe_unretained NSString *height;
	__unsafe_unretained NSString *idPlayer;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *internationalCaps;
	__unsafe_unretained NSString *internationalDebut;
	__unsafe_unretained NSString *jerseyNum;
	__unsafe_unretained NSString *joinDate;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *nationality;
	__unsafe_unretained NSString *pictureUrl;
	__unsafe_unretained NSString *preferredFoot;
	__unsafe_unretained NSString *sportType;
	__unsafe_unretained NSString *thumbnailUrl;
	__unsafe_unretained NSString *topCompetitionDebut;
	__unsafe_unretained NSString *tweetsCount;
	__unsafe_unretained NSString *twitterAccount;
	__unsafe_unretained NSString *twitterBannerUrl;
	__unsafe_unretained NSString *updateable;
	__unsafe_unretained NSString *weight;
} MDPPlayerModelAttributes;

extern const struct MDPPlayerModelRelationships {
	__unsafe_unretained NSString *content;
	__unsafe_unretained NSString *domesticLeague;
	__unsafe_unretained NSString *individualHonours;
	__unsafe_unretained NSString *international;
	__unsafe_unretained NSString *localizedTwitterAccounts;
	__unsafe_unretained NSString *position;
	__unsafe_unretained NSString *realPosition;
	__unsafe_unretained NSString *realPositionSide;
} MDPPlayerModelRelationships;

@class MDPMediaContentModel;
@class MDPCareerDetailModel;
@class MDPHonourModel;
@class MDPCareerDetailModel;
@class MDPLocaleDescriptionModel;
@class MDPKeyValueObjectModel;
@class MDPKeyValueObjectModel;
@class MDPKeyValueObjectModel;

@interface _MDPPlayerModel : NSManagedObject

@property (nonatomic, strong) NSString* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* birthDate;

//- (BOOL)validateBirthDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* birthPlace;

//- (BOOL)validateBirthPlace:(id*)value_ error:(NSError**)error_;

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

@property (nonatomic, strong) NSNumber* internationalCaps;

@property (atomic) uint64_t internationalCapsValue;
- (uint64_t)internationalCapsValue;
- (void)setInternationalCapsValue:(uint64_t)value_;

//- (BOOL)validateInternationalCaps:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* internationalDebut;

//- (BOOL)validateInternationalDebut:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* jerseyNum;

@property (atomic) uint64_t jerseyNumValue;
- (uint64_t)jerseyNumValue;
- (void)setJerseyNumValue:(uint64_t)value_;

//- (BOOL)validateJerseyNum:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* joinDate;

//- (BOOL)validateJoinDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* nationality;

//- (BOOL)validateNationality:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* pictureUrl;

//- (BOOL)validatePictureUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* preferredFoot;

@property (atomic) uint16_t preferredFootValue;
- (uint16_t)preferredFootValue;
- (void)setPreferredFootValue:(uint16_t)value_;

//- (BOOL)validatePreferredFoot:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* sportType;

@property (atomic) uint16_t sportTypeValue;
- (uint16_t)sportTypeValue;
- (void)setSportTypeValue:(uint16_t)value_;

//- (BOOL)validateSportType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* thumbnailUrl;

//- (BOOL)validateThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* topCompetitionDebut;

//- (BOOL)validateTopCompetitionDebut:(id*)value_ error:(NSError**)error_;

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

@property (nonatomic, strong) NSSet *domesticLeague;

- (NSMutableSet*)domesticLeagueSet;

@property (nonatomic, strong) NSSet *individualHonours;

- (NSMutableSet*)individualHonoursSet;

@property (nonatomic, strong) NSSet *international;

- (NSMutableSet*)internationalSet;

@property (nonatomic, strong) NSSet *localizedTwitterAccounts;

- (NSMutableSet*)localizedTwitterAccountsSet;

@property (nonatomic, strong) MDPKeyValueObjectModel *position;

//- (BOOL)validatePosition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *realPosition;

//- (BOOL)validateRealPosition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *realPositionSide;

//- (BOOL)validateRealPositionSide:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPlayerModel (ContentCoreDataGeneratedAccessors)
- (void)addContent:(NSSet*)value_;
- (void)removeContent:(NSSet*)value_;
- (void)addContentObject:(MDPMediaContentModel*)value_;
- (void)removeContentObject:(MDPMediaContentModel*)value_;
@end

@interface _MDPPlayerModel (DomesticLeagueCoreDataGeneratedAccessors)
- (void)addDomesticLeague:(NSSet*)value_;
- (void)removeDomesticLeague:(NSSet*)value_;
- (void)addDomesticLeagueObject:(MDPCareerDetailModel*)value_;
- (void)removeDomesticLeagueObject:(MDPCareerDetailModel*)value_;
@end

@interface _MDPPlayerModel (IndividualHonoursCoreDataGeneratedAccessors)
- (void)addIndividualHonours:(NSSet*)value_;
- (void)removeIndividualHonours:(NSSet*)value_;
- (void)addIndividualHonoursObject:(MDPHonourModel*)value_;
- (void)removeIndividualHonoursObject:(MDPHonourModel*)value_;
@end

@interface _MDPPlayerModel (InternationalCoreDataGeneratedAccessors)
- (void)addInternational:(NSSet*)value_;
- (void)removeInternational:(NSSet*)value_;
- (void)addInternationalObject:(MDPCareerDetailModel*)value_;
- (void)removeInternationalObject:(MDPCareerDetailModel*)value_;
@end

@interface _MDPPlayerModel (LocalizedTwitterAccountsCoreDataGeneratedAccessors)
- (void)addLocalizedTwitterAccounts:(NSSet*)value_;
- (void)removeLocalizedTwitterAccounts:(NSSet*)value_;
- (void)addLocalizedTwitterAccountsObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeLocalizedTwitterAccountsObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPPlayerModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAlias;
- (void)setPrimitiveAlias:(NSString*)value;

- (NSDate*)primitiveBirthDate;
- (void)setPrimitiveBirthDate:(NSDate*)value;

- (NSString*)primitiveBirthPlace;
- (void)setPrimitiveBirthPlace:(NSString*)value;

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

- (NSNumber*)primitiveInternationalCaps;
- (void)setPrimitiveInternationalCaps:(NSNumber*)value;

- (uint64_t)primitiveInternationalCapsValue;
- (void)setPrimitiveInternationalCapsValue:(uint64_t)value_;

- (NSDate*)primitiveInternationalDebut;
- (void)setPrimitiveInternationalDebut:(NSDate*)value;

- (NSNumber*)primitiveJerseyNum;
- (void)setPrimitiveJerseyNum:(NSNumber*)value;

- (uint64_t)primitiveJerseyNumValue;
- (void)setPrimitiveJerseyNumValue:(uint64_t)value_;

- (NSDate*)primitiveJoinDate;
- (void)setPrimitiveJoinDate:(NSDate*)value;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSString*)primitiveNationality;
- (void)setPrimitiveNationality:(NSString*)value;

- (NSString*)primitivePictureUrl;
- (void)setPrimitivePictureUrl:(NSString*)value;

- (NSNumber*)primitivePreferredFoot;
- (void)setPrimitivePreferredFoot:(NSNumber*)value;

- (uint16_t)primitivePreferredFootValue;
- (void)setPrimitivePreferredFootValue:(uint16_t)value_;

- (NSNumber*)primitiveSportType;
- (void)setPrimitiveSportType:(NSNumber*)value;

- (uint16_t)primitiveSportTypeValue;
- (void)setPrimitiveSportTypeValue:(uint16_t)value_;

- (NSString*)primitiveThumbnailUrl;
- (void)setPrimitiveThumbnailUrl:(NSString*)value;

- (NSDate*)primitiveTopCompetitionDebut;
- (void)setPrimitiveTopCompetitionDebut:(NSDate*)value;

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

- (NSMutableSet*)primitiveDomesticLeague;
- (void)setPrimitiveDomesticLeague:(NSMutableSet*)value;

- (NSMutableSet*)primitiveIndividualHonours;
- (void)setPrimitiveIndividualHonours:(NSMutableSet*)value;

- (NSMutableSet*)primitiveInternational;
- (void)setPrimitiveInternational:(NSMutableSet*)value;

- (NSMutableSet*)primitiveLocalizedTwitterAccounts;
- (void)setPrimitiveLocalizedTwitterAccounts:(NSMutableSet*)value;

- (MDPKeyValueObjectModel*)primitivePosition;
- (void)setPrimitivePosition:(MDPKeyValueObjectModel*)value;

- (MDPKeyValueObjectModel*)primitiveRealPosition;
- (void)setPrimitiveRealPosition:(MDPKeyValueObjectModel*)value;

- (MDPKeyValueObjectModel*)primitiveRealPositionSide;
- (void)setPrimitiveRealPositionSide:(MDPKeyValueObjectModel*)value;

@end
