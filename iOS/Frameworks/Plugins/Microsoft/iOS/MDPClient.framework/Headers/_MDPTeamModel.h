//
//  _MDPTeamModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPTeamModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPTeamModelAttributes {
	__unsafe_unretained NSString *businessName;
	__unsafe_unretained NSString *city;
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *displayName;
	__unsafe_unretained NSString *foundationYear;
	__unsafe_unretained NSString *headquarters;
	__unsafe_unretained NSString *idCountry;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *officialSite;
	__unsafe_unretained NSString *postalCode;
	__unsafe_unretained NSString *regionName;
	__unsafe_unretained NSString *shortClubName;
	__unsafe_unretained NSString *sportType;
	__unsafe_unretained NSString *street;
	__unsafe_unretained NSString *teamBadgeName;
	__unsafe_unretained NSString *teamBadgeThumbnailName;
	__unsafe_unretained NSString *teamType;
	__unsafe_unretained NSString *trainingCentre;
	__unsafe_unretained NSString *updateable;
} MDPTeamModelAttributes;

extern const struct MDPTeamModelRelationships {
	__unsafe_unretained NSString *content;
	__unsafe_unretained NSString *honours;
	__unsafe_unretained NSString *officials;
	__unsafe_unretained NSString *playerChanges;
	__unsafe_unretained NSString *stadium;
} MDPTeamModelRelationships;

@class MDPMediaContentModel;
@class MDPHonourModel;
@class MDPTeamOfficialModel;
@class MDPPlayerChangeModel;
@class MDPVenueModel;

@interface _MDPTeamModel : NSManagedObject

@property (nonatomic, strong) NSString* businessName;

//- (BOOL)validateBusinessName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* city;

//- (BOOL)validateCity:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* country;

//- (BOOL)validateCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* displayName;

//- (BOOL)validateDisplayName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* foundationYear;

@property (atomic) uint64_t foundationYearValue;
- (uint64_t)foundationYearValue;
- (void)setFoundationYearValue:(uint64_t)value_;

//- (BOOL)validateFoundationYear:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* headquarters;

//- (BOOL)validateHeadquarters:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCountry;

//- (BOOL)validateIdCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* officialSite;

//- (BOOL)validateOfficialSite:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* postalCode;

//- (BOOL)validatePostalCode:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* regionName;

//- (BOOL)validateRegionName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* shortClubName;

//- (BOOL)validateShortClubName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* sportType;

@property (atomic) uint16_t sportTypeValue;
- (uint16_t)sportTypeValue;
- (void)setSportTypeValue:(uint16_t)value_;

//- (BOOL)validateSportType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* street;

//- (BOOL)validateStreet:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamBadgeName;

//- (BOOL)validateTeamBadgeName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamBadgeThumbnailName;

//- (BOOL)validateTeamBadgeThumbnailName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* teamType;

@property (atomic) uint16_t teamTypeValue;
- (uint16_t)teamTypeValue;
- (void)setTeamTypeValue:(uint16_t)value_;

//- (BOOL)validateTeamType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* trainingCentre;

//- (BOOL)validateTrainingCentre:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* updateable;

@property (atomic) BOOL updateableValue;
- (BOOL)updateableValue;
- (void)setUpdateableValue:(BOOL)value_;

//- (BOOL)validateUpdateable:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *content;

- (NSMutableSet*)contentSet;

@property (nonatomic, strong) NSSet *honours;

- (NSMutableSet*)honoursSet;

@property (nonatomic, strong) NSSet *officials;

- (NSMutableSet*)officialsSet;

@property (nonatomic, strong) NSSet *playerChanges;

- (NSMutableSet*)playerChangesSet;

@property (nonatomic, strong) MDPVenueModel *stadium;

//- (BOOL)validateStadium:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPTeamModel (ContentCoreDataGeneratedAccessors)
- (void)addContent:(NSSet*)value_;
- (void)removeContent:(NSSet*)value_;
- (void)addContentObject:(MDPMediaContentModel*)value_;
- (void)removeContentObject:(MDPMediaContentModel*)value_;
@end

@interface _MDPTeamModel (HonoursCoreDataGeneratedAccessors)
- (void)addHonours:(NSSet*)value_;
- (void)removeHonours:(NSSet*)value_;
- (void)addHonoursObject:(MDPHonourModel*)value_;
- (void)removeHonoursObject:(MDPHonourModel*)value_;
@end

@interface _MDPTeamModel (OfficialsCoreDataGeneratedAccessors)
- (void)addOfficials:(NSSet*)value_;
- (void)removeOfficials:(NSSet*)value_;
- (void)addOfficialsObject:(MDPTeamOfficialModel*)value_;
- (void)removeOfficialsObject:(MDPTeamOfficialModel*)value_;
@end

@interface _MDPTeamModel (PlayerChangesCoreDataGeneratedAccessors)
- (void)addPlayerChanges:(NSSet*)value_;
- (void)removePlayerChanges:(NSSet*)value_;
- (void)addPlayerChangesObject:(MDPPlayerChangeModel*)value_;
- (void)removePlayerChangesObject:(MDPPlayerChangeModel*)value_;
@end

@interface _MDPTeamModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveBusinessName;
- (void)setPrimitiveBusinessName:(NSString*)value;

- (NSString*)primitiveCity;
- (void)setPrimitiveCity:(NSString*)value;

- (NSString*)primitiveCountry;
- (void)setPrimitiveCountry:(NSString*)value;

- (NSString*)primitiveDisplayName;
- (void)setPrimitiveDisplayName:(NSString*)value;

- (NSNumber*)primitiveFoundationYear;
- (void)setPrimitiveFoundationYear:(NSNumber*)value;

- (uint64_t)primitiveFoundationYearValue;
- (void)setPrimitiveFoundationYearValue:(uint64_t)value_;

- (NSString*)primitiveHeadquarters;
- (void)setPrimitiveHeadquarters:(NSString*)value;

- (NSString*)primitiveIdCountry;
- (void)setPrimitiveIdCountry:(NSString*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSString*)primitiveOfficialSite;
- (void)setPrimitiveOfficialSite:(NSString*)value;

- (NSString*)primitivePostalCode;
- (void)setPrimitivePostalCode:(NSString*)value;

- (NSString*)primitiveRegionName;
- (void)setPrimitiveRegionName:(NSString*)value;

- (NSString*)primitiveShortClubName;
- (void)setPrimitiveShortClubName:(NSString*)value;

- (NSNumber*)primitiveSportType;
- (void)setPrimitiveSportType:(NSNumber*)value;

- (uint16_t)primitiveSportTypeValue;
- (void)setPrimitiveSportTypeValue:(uint16_t)value_;

- (NSString*)primitiveStreet;
- (void)setPrimitiveStreet:(NSString*)value;

- (NSString*)primitiveTeamBadgeName;
- (void)setPrimitiveTeamBadgeName:(NSString*)value;

- (NSString*)primitiveTeamBadgeThumbnailName;
- (void)setPrimitiveTeamBadgeThumbnailName:(NSString*)value;

- (NSNumber*)primitiveTeamType;
- (void)setPrimitiveTeamType:(NSNumber*)value;

- (uint16_t)primitiveTeamTypeValue;
- (void)setPrimitiveTeamTypeValue:(uint16_t)value_;

- (NSString*)primitiveTrainingCentre;
- (void)setPrimitiveTrainingCentre:(NSString*)value;

- (NSNumber*)primitiveUpdateable;
- (void)setPrimitiveUpdateable:(NSNumber*)value;

- (BOOL)primitiveUpdateableValue;
- (void)setPrimitiveUpdateableValue:(BOOL)value_;

- (NSMutableSet*)primitiveContent;
- (void)setPrimitiveContent:(NSMutableSet*)value;

- (NSMutableSet*)primitiveHonours;
- (void)setPrimitiveHonours:(NSMutableSet*)value;

- (NSMutableSet*)primitiveOfficials;
- (void)setPrimitiveOfficials:(NSMutableSet*)value;

- (NSMutableSet*)primitivePlayerChanges;
- (void)setPrimitivePlayerChanges:(NSMutableSet*)value;

- (MDPVenueModel*)primitiveStadium;
- (void)setPrimitiveStadium:(MDPVenueModel*)value;

@end
